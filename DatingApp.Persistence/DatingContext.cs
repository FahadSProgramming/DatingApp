using DatingApp.Core;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Persistence
{
    public class DatingContext : DbContext
    {
        public DatingContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
    }
}
