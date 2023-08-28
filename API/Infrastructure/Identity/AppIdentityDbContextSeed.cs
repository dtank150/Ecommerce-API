using API.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Tom",
                    Email = "tom@gmail.com",
                    UserName = "tom@gmail.com",
                    Address = new Address
                    {
                        FirstName = "Tom",
                        LastName = "Jerry",
                        Street = "12 The Street",
                        City = "New York",
                        State = "NY",
                        ZipCode = "90210"
                    },
                };


                await userManager.CreateAsync(user, "1234");
            }
        }
    }
}
