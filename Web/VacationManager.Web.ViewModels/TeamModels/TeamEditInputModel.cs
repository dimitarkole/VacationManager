namespace VacationManager.Web.ViewModels.TeamModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using VacationManager.Data.Models;
    using VacationManager.Services.Mapping;

    using static VacationManager.Common.ModelConstants;

    public class TeamEditInputModel : IMapTo<Team>
    {
        [Required]
        [MaxLength(TeamModelsConstants.TeamNameMaxLength)]
        public string Name { get; set; }

        public int? ProjectId { get; set; }
    }
}
