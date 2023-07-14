using DatingApp.Core;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace DatingApp.Persistence.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DatingContext context)
        {
            if (await context.Users.AnyAsync()) { return; }
            var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData, options);
            foreach(var user in users)
            {
                user.Username = user.Username.ToLower();
                context.Users.Add(user);
            }
            await context.SaveChangesAsync();
        }
    }
}
