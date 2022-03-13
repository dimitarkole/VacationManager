namespace VacationManager.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using VacationManager.Common.Extensions;
    using VacationManager.Data;
    using VacationManager.Data.Models;
    using VacationManager.Services.Mapping;
    using VacationManager.Web.ViewModels.TeamModels;

    public class TeamService : ITeamService
    {
        private readonly ApplicationDbContext context;
        private readonly IPaginationService paginationService;

        public TeamService(
            ApplicationDbContext context,
            IPaginationService paginationService)
        {
            this.context = context;
            this.paginationService = paginationService;
        }

        public TeamsAllViewModel<T> All<T>(int page, int entitesPerPage)
        {
            var teams = this.context.Teams
                   .OrderBy(r => r.Name)
                   .To<T>();

            return new TeamsAllViewModel<T>()
            {
                Teams = teams
                  .GetPage(page, entitesPerPage)
                  .ToList(),
                CurrentPage = page,
                NumberOfPages = this.GetItemsPagesCount(teams.Count(), entitesPerPage),
            };
        }

        public async Task AssignDeveloper(int id, string userId)
        {
            var team = this.context.Teams.Find(id);
            var user = this.context.Users.Find(userId);
            team.Developers.Add(user);
            user.TeamId = id;

            this.context.Teams.Update(team);
            this.context.Users.Update(user);
            await this.context.SaveChangesAsync();
        }

        public async Task AssignTeamLeader(int id, string userId)
        {
            var team = this.context.Teams.Find(id);
            var user = this.context.Users.Find(userId);
            team.TeamLeadId = userId;
            user.LedTeams.Add(team);

            this.context.Teams.Update(team);
            this.context.Users.Update(user);
            await this.context.SaveChangesAsync();
        }

        public async Task Create(TeamCreateInputModel model)
        {
            var team = model.To<Team>();
            await this.context.Teams.AddAsync(team);
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var team = this.context.Teams.Find(id);
            this.context.Teams.Remove(team);
            await this.context.SaveChangesAsync();
        }

        public TeamsAllViewModel<T> Filter<T>(TeamFilter filter, int page, int entitesPerPage)
        {
            IQueryable<Team> teams = this.context.Teams;
            teams = FilteringTeams(filter, teams);

            var teamsT = teams
                .OrderBy(r => r.Name)
                .To<T>();

            return new TeamsAllViewModel<T>()
            {
                Teams = teamsT
                  .GetPage(page, entitesPerPage)
                  .ToList(),
                CurrentPage = page,
                NumberOfPages = this.GetItemsPagesCount(teams.Count(), entitesPerPage),
            };
        }

        public TeamDetailsModel<TTeam, TDevelopers> GetById<TTeam, TDevelopers>(int id, int page, int entitesPerPage)
        {
            var team = this.context.Teams
                .Where(t => t.Id == id)
                .To<TTeam>()
                .FirstOrDefault();

            var developers = this.context.Users
                .Where(u => u.TeamId == id)
                .OrderBy(u => u.UserName)
                .To<TDevelopers>();

            return new TeamDetailsModel<TTeam, TDevelopers>()
            {
                Team = team,
                Developers = developers
                    .GetPage(page, entitesPerPage)
                    .ToList(),
                CurrentPage = page,
                NumberOfPages = this.GetItemsPagesCount(developers.Count(), entitesPerPage),
            };
        }

        public IEnumerable<T> GetNotAssignDevelopers<T>()
            => this.context.Users
                .Where(u => u.TeamId == null)
                .OrderBy(u => u.UserName)
                .To<T>()
                .ToList();

        public async Task Update(TeamEditInputModel model, int id)
        {
            var team = this.context.Teams.Find(id);
            model.To<ApplicationRole>(team);

            this.context.Teams.Update(team);
            await this.context.SaveChangesAsync();
        }

        private int GetItemsPagesCount(int entityCount, int entitesPerPage)
          => this.paginationService.CalculatePagesCount(entityCount, entitesPerPage);

        private static IQueryable<Team> FilteringTeams(TeamFilter filter, IQueryable<Team> teams)
        {
            if (!string.IsNullOrEmpty(filter.ProjectName))
            {
                teams = teams.Where(t => t.Project.Name.ToLower().Contains(filter.ProjectName.ToLower()));
            }

            if (!string.IsNullOrEmpty(filter.TeamName))
            {
                teams = teams.Where(t => t.Name.ToLower().Contains(filter.TeamName.ToLower()));
            }

            return teams;
        }
    }
}
