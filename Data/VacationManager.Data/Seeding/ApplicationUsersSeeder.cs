using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VacationManager.Data.Models;
using static VacationManager.Common.GlobalConstants;

namespace VacationManager.Data.Seeding
{
    public class ApplicationUsersSeeder : ISeeder
    {
        public class User
        {
            public string Username { get; set; }

            public string Email { get; set; }

            public string Password { get; set; }

            public string Role { get; set; }
        }

        public List<User> Users = new List<User>()
        {
            new User() { Username = "rootadmin", Email = "rootadmin@abv.bg",  Password = "rootpass",  Role = Roles.Administrator },
            new User() { Username = "rootceo", Email = "rootceo@abv.bg", Password = "rootpass", Role = Roles.CEO },
            new User() { Username = "rootteamleader", Email = "rootteamleader@abv.bg", Password = "rootpass", Role = Roles.TeamLeader },
            new User() { Username = "rootteamleader1", Email = "rootteamleader1@abv.bg", Password = "rootpass", Role = Roles.TeamLeader },
            new User() { Username = "rootteamleader2", Email = "rootteamleader2@abv.bg", Password = "rootpass", Role = Roles.TeamLeader },
            new User() { Username = "rootuser", Email = "rootuser@abv.bg", Password = "rootpass", Role = Roles.Developer },
            new User() { Username = "rootuser1", Email = "rootuser1@abv.bg", Password = "rootpass", Role = Roles.Developer },
            new User() { Username = "rootuser2", Email = "rootuser2@abv.bg", Password = "rootpass", Role = Roles.Developer },
            new User() { Username = "pesho", Email = "pesho@abv.bg", Password = "rootpass", Role = Roles.Unassigned },
            new User() { Username = "gosho", Email = "gosho@abv.bg", Password = "rootpass", Role = Roles.Unassigned },
        };

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            foreach (var user in this.Users)
            {
                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var userFromDb = await userManager.FindByNameAsync(user.Username);

                if (userFromDb == null)
                {
                    var userAdd = new ApplicationUser
                    {
                        UserName = user.Username,
                        FirstName = "Root",
                        LastName = "Root",
                        Email = user.Email,
                        EmailConfirmed = true,
                    };

                    await userManager.CreateAsync(userAdd, user.Password);
                    await userManager.AddToRoleAsync(userAdd, user.Role);
                }
            }
        }
    }
}
