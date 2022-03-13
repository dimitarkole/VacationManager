namespace VacationManager.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using VacationManager.Web.ViewModels.TeamModels;

    public interface ITeamService
    {
        Task Create(TeamCreateInputModel model);

        Task Delete(int id);

        Task Update(TeamEditInputModel model, int id);

        TeamsAllViewModel<T> All<T>(int page, int entitesPerPage);

        TeamsAllViewModel<T> Filter<T>(TeamFilter filter, int page, int entitesPerPage);

        Task AssignTeamLeader(int id, string userId);

        Task AssignDeveloper(int id, string userId);

        IEnumerable<T> GetNotAssignDevelopers<T>();

        TeamDetailsModel<TTeam, TDevelopers> GetById<TTeam, TDevelopers>(int id, int page, int entitesPerPage);
    }
}
