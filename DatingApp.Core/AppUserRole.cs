using Microsoft.AspNetCore.Identity;

namespace DatingApp.Core
{
    public class AppUserRole : IdentityUserRole<Guid>
    {
        public AppUser User { get; set; }
        public AppRole Role { get; set; }
    }
}
