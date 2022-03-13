namespace VacationManager.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using VacationManager.Data.Models;

    public class ProjectsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var projects = this.GetProjects().OrderBy(x => x.Name).ToArray();

            foreach (var project in projects)
            {
                if (!dbContext.Projects.Any(p => p.Name == project.Name))
                {
                    await dbContext.Projects.AddAsync(project);
                }
            }
        }

        private Project[] GetProjects()
            => new Project[]
                {
                    new Project(){ Name = "Vacation Manager", Description = "Vacation Manager is paid project."},
                    new Project(){ Name = "Case Manager", Description = "Case Manager is manager system." },
                    new Project(){ Name = "ECar", Description = "ECar is the car of futere." },
                    new Project(){ Name = "EBank", Description = "EBank is mobile project."},
                    new Project(){ Name = "Sound Manager", Description = "Sound Manager is paid project."},
                };
    }
}
