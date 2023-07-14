using DatingApp.Core;

namespace DatingApp.Application.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserByIdAsync(Guid userId);
        Task<AppUser> GetUserByUsernameAsync(string username);
    }
}
