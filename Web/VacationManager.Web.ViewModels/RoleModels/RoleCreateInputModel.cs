namespace VacationManager.Web.ViewModels.RoleModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using VacationManager.Data.Models;
    using VacationManager.Services.Mapping;

    using static VacationManager.Common.ModelConstants;

    public class RoleCreateInputModel : IMapTo<ApplicationRole>
    {
        [Required]
        [MaxLength(RoleModelsConstants.RoleNameMaxLength)]
        public string Name { get; set; }
    }
}
