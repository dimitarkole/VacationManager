namespace VacationManager.Web.ViewModels.RoleModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.AspNetCore.Identity;
    using VacationManager.Services.Mapping;
    using VacationManager.Web.ViewModels.UserModels;

    public class IdentityUserRoleViewModel : IMapFrom<IdentityUserRole<string>>
    {
        public string UserId { get; set; }

        public string RoleId { get; set; }

        public UserViewModel User { get; set; }
    }
}
