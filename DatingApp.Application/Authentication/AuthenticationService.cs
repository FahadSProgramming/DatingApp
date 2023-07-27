using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatingApp.Application.Interfaces;
using DatingApp.Core;
using DatingApp.Persistence.DTO;
using DatingApp.Persistence.DTO.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Application.Authentication {
    public class AuthenticationService : IAuthenticationService {

        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;

        public AuthenticationService(ITokenService tokenService, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper) {
            _tokenService = tokenService;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public async Task<LoginResponse> Login(LoginRequest request) {
            if (!await UserExists(request.UserName)) {
                return FailedResult();
            }

            var user = await _userManager.Users
                .Include(p => p.Photos)
                .Where(x => x.UserName.ToLowerInvariant() == request.UserName.ToLowerInvariant())
                // .ProjectTo<AppUserDTO>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();

            if (user == null) {
                return FailedResult();
            }
            var token = await _tokenService.GenerateToken(user);
            return new LoginResponse {
                Success = true,
                User = _mapper.Map<AppUserDTO>(user),
                Token = token
            };
        }

        public async Task<LoginResponse> Register(RegistrationRequest request) {

            if (await UserExists(request.UserName)) {
                return FailedResult();
            }
            var user = _mapper.Map<AppUser>(request);
            user.UserName = user.UserName.ToLowerInvariant();
            var userResult = await _userManager.CreateAsync(user);
            if (!userResult.Succeeded) {
                return FailedResult();
            }
            var roleResult = await _userManager.AddToRoleAsync(user, "Member");
            if (!roleResult.Succeeded) {
                return FailedResult();
            }

            var token = await _tokenService.GenerateToken(user);
            return new LoginResponse {
                Success = true,
                Token = token
            };
        }

        public async Task<bool> UserExists(string userName) {
            return await _userManager.Users.AnyAsync(x => x.UserName.ToLowerInvariant() == userName.ToLowerInvariant());
        }

        private LoginResponse FailedResult() {
            return new LoginResponse {
                Success = false
            };
        }
    }
}
