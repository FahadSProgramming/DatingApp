using Microsoft.AspNetCore.Identity;

namespace DatingApp.Core
{
    public class AppRole : IdentityRole<Guid>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
