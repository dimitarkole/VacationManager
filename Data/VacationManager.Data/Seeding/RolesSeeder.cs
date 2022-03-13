namespace VacationManager.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using VacationManager.Common;
    using VacationManager.Data.Models;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    internal class RolesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            await SeedRoleAsync(roleManager, GlobalConstants.Roles.Administrator);
            await SeedRoleAsync(roleManager, GlobalConstants.Roles.CEO);
            await SeedRoleAsync(roleManager, GlobalConstants.Roles.TeamLeader);
            await SeedRoleAsync(roleManager, GlobalConstants.Roles.Developer);
            await SeedRoleAsync(roleManager, GlobalConstants.Roles.Unassigned);
        }

        private static async Task SeedRoleAsync(RoleManager<ApplicationRole> roleManager, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                var result = await roleManager.CreateAsync(new ApplicationRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
