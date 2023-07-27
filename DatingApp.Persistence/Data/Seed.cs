using DatingApp.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace DatingApp.Persistence.Data {
    public class Seed {
        public static async Task SeedUsers(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager) {
            if (await userManager.Users.AnyAsync()) { return; }
            var userData = await File.ReadAllTextAsync("../DatingApp.Persistence/Data/UserSeedData.json");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData, options);
            var userRoles = new List<AppRole> {
                new AppRole {Name = "Member" },
                new AppRole {Name = "Moderator" },
                new AppRole {Name = "Administrator" },
            };
            foreach(var role in userRoles) {
                await roleManager.CreateAsync(role);
            }

            foreach (var user in users) {
                user.UserName = user.UserName.ToLower();
                await userManager.CreateAsync(user, "Abcd1234");
                await userManager.AddToRoleAsync(user, "Member");

            }
            var admin = new AppUser { UserName = "admin" };
            await userManager.CreateAsync(admin, "Abcd1234");
            await userManager.AddToRolesAsync(admin, new[] { "Administrator", "Moderator" });
        }
    }
}
