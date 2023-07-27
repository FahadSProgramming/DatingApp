namespace DatingApp.Persistence.DTO.Authentication {
    public class RegistrationRequest {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
