namespace VacationManager.Web.ViewModels.RoleModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using VacationManager.Web.ViewModels.PaginationModels;

    public class RolesAllViewModel
    {
        public IEnumerable<RoleViewModel> Roles { get; set; }

        public PaginationData PaginationData { get; set; }
    }
}
