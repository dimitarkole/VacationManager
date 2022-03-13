namespace VacationManager.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using VacationManager.Data.Models;

    using static VacationManager.Common.GlobalConstants;

    public class TeamsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var teamNames = this.GetProjects().OrderBy(x => x).ToArray();
            var teamLeaderRoleId = dbContext.Roles
                .Where(r => r.Name == Roles.TeamLeader)
                .FirstOrDefault()
                .Id;

            var teamsLeaders = dbContext.Users
                .Where(u => u.Roles.Any(r => r.RoleId == teamLeaderRoleId))
                .ToList();
            var projects = dbContext.Projects.ToList();
            foreach (var teamName in teamNames)
            {
                if (!dbContext.Teams.Any(t => t.Name == teamName))
                {
                    var project = projects.FirstOrDefault();
                    var teamLeader = teamsLeaders.FirstOrDefault();

                    var team = new Team()
                    {
                        Name = teamName,
                        ProjectId = project?.Id,
                        TeamLeadId = teamLeader?.Id,
                        Developers = new List<ApplicationUser>()
                    };

                    await dbContext.Teams.AddAsync(team);

                    projects.Remove(project);
                    teamsLeaders.Remove(teamLeader);
                }
            }
        }

        private string[] GetProjects()
            => new string[]
                {
                    "Vacation Manager Team",
                    "Case Manager Team" ,
                    "ECar Team",
                    "EBank Team",
                    "Sound Manager Team",
                };
    }
}
