namespace VacationManager.Web.ViewModels.UserModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using VacationManager.Data.Models;
    using VacationManager.Services.Mapping;
    using VacationManager.Web.ViewModels.RoleModels;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<RoleViewModel> Roles { get; set; }
    }
}
