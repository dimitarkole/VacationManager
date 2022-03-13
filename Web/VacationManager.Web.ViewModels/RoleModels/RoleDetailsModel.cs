namespace VacationManager.Web.ViewModels.RoleModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using VacationManager.Data.Models;
    using VacationManager.Services.Mapping;
    using VacationManager.Web.ViewModels.PaginationModels;
    using VacationManager.Web.ViewModels.UserModels;

    public class RoleDetailsModel : IMapFrom<ApplicationRole>
    {
        public PaginationData PaginationData { get; set; }

        public RoleViewModel Role { get; set; }

        public ICollection<UserViewModel> Users { get; set; }

        public int TotalUsersCount { get; set; }
    }
}
