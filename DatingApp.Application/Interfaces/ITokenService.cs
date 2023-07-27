using DatingApp.Core;
using Microsoft.AspNetCore.Identity;

namespace DatingApp.Application.Interfaces {
    public interface ITokenService {
        Task<string> GenerateToken(AppUser user, UserManager<AppUser> userManager);
    }
}
