namespace DatingApp.Core
{
    public class AppUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public DateOnly BirthDate { get; set; }
        public string KnownAs { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime LastActive { get; set; } = DateTime.UtcNow;
        public bool Gender { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Photo> Photos { get; set; } = new();

        //public static int GetAge(this DateOnly birthDate)
        //{
        //    var today = DateOnly.FromDateTime(DateTime.UtcNow);
        //    var age = today.Year - birthDate.Year;
        //    return birthDate > today.AddYears(-age) ? age - 1 : age;
        //}

    } // Class: AppUser

} // Namespace: DatingApp.Core