namespace VacationManager.Web.ViewModels.UserModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using VacationManager.Data.Models;
    using VacationManager.Services.Mapping;

    public class UserSmallViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string UserName { get; set; }
    }
}
