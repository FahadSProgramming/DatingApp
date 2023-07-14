﻿namespace DatingApp.Persistence.DTO
{
    public class AppUserDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public DateOnly BirthDate { get; set; }
        public string KnownAs { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastActive { get; set; }
        public bool Gender { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<PhotoDTO> Photos { get; set; } = new();
    }
}
