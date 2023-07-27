using DatingApp.Core;
using DatingApp.Persistence.DTO;

namespace DatingApp.Application.Interfaces {
    public interface ITokenService {
        Task<string> GenerateToken(AppUser user);
    }
}
