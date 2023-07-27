using DatingApp.Application.Interfaces;
using DatingApp.Core;
using DatingApp.Persistence.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DatingApp.Application.Authentication
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey secretKey;
        private readonly UserManager<AppUser> userManager;
        public TokenService(SymmetricSecurityKey tokenGenerationKey, UserManager<AppUser> _userManager = null)
        {
            secretKey = tokenGenerationKey;
            userManager = _userManager;
        }
        public async Task<string> GenerateToken(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };
            var roles = await userManager.GetRolesAsync(user);
            var creds = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha512Signature);

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateToken(string[] attributes)
        {
            throw new NotImplementedException();
        }
    }
}
