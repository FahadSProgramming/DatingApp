using DatingApp.Persistence.DTO;

namespace DatingApp.Application.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUserDTO user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppUserDTO>> GetUsersAsync();
        Task<AppUserDTO> GetUserByIdAsync(Guid userId);
        Task<AppUserDTO> GetUserByUsernameAsync(string username);
    }
}
