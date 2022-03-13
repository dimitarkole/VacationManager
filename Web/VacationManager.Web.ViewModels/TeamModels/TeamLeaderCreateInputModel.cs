namespace VacationManager.Web.ViewModels.TeamModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using VacationManager.Data.Models;
    using VacationManager.Services.Mapping;

    public class TeamLeaderCreateInputModel : IMapTo<Team>
    {
        public string TeamLeadId { get; set; }
    }
}
