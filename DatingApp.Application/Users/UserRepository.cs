using DatingApp.Application.Interfaces;
using DatingApp.Core;
using DatingApp.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Application.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly DatingContext context;
        public UserRepository(DatingContext _context)
        {
            context = _context;
        }
        public async Task<AppUser> GetUserByIdAsync(Guid userId)
        {
            return await context.Users.FindAsync(userId);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await context.Users.SingleOrDefaultAsync(user => user.Username == username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            context.Entry(user).State = EntityState.Modified;
        }
    }
}
