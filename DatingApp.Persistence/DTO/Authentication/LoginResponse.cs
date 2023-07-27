namespace DatingApp.Persistence.DTO.Authentication {
    public class LoginResponse {
        public AppUserDTO User { get; set; }
        public bool Success { get; set; }
        public string Token { get; set; }
    }
}
