namespace VacationManager.Web.ViewModels.TeamModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    using VacationManager.Data.Models;
    using VacationManager.Services.Mapping;
    using VacationManager.Web.ViewModels.ProjectModels;
    using VacationManager.Web.ViewModels.UserModels;

    public class TeamDetailsModel<TTeam, TDevelopers> : IMapFrom<Team>
    {
        public TTeam Team { get; set; }

        public ICollection<TDevelopers> Developers { get; set; }

        public int NumberOfPages { get; set; }

        public int CurrentPage { get; set; }
    }
}
