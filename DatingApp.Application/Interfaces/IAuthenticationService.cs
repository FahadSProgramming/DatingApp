using DatingApp.Persistence.DTO.Authentication;

namespace DatingApp.Application.Interfaces {
    public interface IAuthenticationService {
        Task<LoginResponse> Register(RegistrationRequest request);
        Task<LoginResponse> Login(LoginRequest request);
        Task<bool> UserExists(string userName);
    }
}
