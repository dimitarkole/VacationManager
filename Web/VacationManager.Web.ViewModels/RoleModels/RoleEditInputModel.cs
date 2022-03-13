namespace VacationManager.Web.ViewModels.RoleModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using VacationManager.Data.Models;
    using VacationManager.Services.Mapping;

    using static VacationManager.Common.ModelConstants;

    public class RoleEditInputModel : IMapFrom<ApplicationRole>, IMapTo<ApplicationRole>
    {
        [Required]
        [MaxLength(RoleModelsConstants.RoleNameMaxLength)]
        public string Name { get; set; }
    }
}
