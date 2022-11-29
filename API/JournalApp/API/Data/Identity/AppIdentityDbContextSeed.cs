using API.Entites.Identity;
using Microsoft.AspNetCore.Identity;

namespace API.Data.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                AppUser user = new()
                {
                    Email = "test@gmail.com",
                    FirstName = "Test",
                    LastName = "User"
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}
