using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatingApp.Application.Interfaces;
using DatingApp.Persistence;
using DatingApp.Persistence.DTO;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Application.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly DatingContext context;
        private readonly IMapper mapper;
        public UserRepository(DatingContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }
        public async Task<AppUserDTO> GetUserByIdAsync(Guid userId)
        {
            var user = await context.Users.FindAsync(userId);
            return mapper.Map<AppUserDTO>(user);
        }

        public async Task<AppUserDTO> GetUserByUsernameAsync(string username)
        {
            var user = await context.Users
                .Include(p => p.Photos)
                .Where(x => x.UserName.ToLowerInvariant() == username.ToLowerInvariant())
                .ProjectTo<AppUserDTO>(mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
            return user ?? null;
        }

        public async Task<IEnumerable<AppUserDTO>> GetUsersAsync()
        {
            var users = await context.Users.ToListAsync();
            return mapper.Map<IEnumerable<AppUserDTO>>(users);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void Update(AppUserDTO user)
        {
            context.Entry(user).State = EntityState.Modified;
        }
    }
}
