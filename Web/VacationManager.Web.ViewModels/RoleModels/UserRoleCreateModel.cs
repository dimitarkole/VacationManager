namespace VacationManager.Web.ViewModels.RoleModels
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using VacationManager.Services.Mapping;

    public class UserRoleCreateModel : IMapTo<IdentityUserRole<string>>
    {
        public virtual string UserId { get; set; }

        public virtual string RoleId { get; set; }
    }
}
