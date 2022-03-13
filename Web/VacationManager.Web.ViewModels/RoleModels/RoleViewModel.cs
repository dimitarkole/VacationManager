namespace VacationManager.Web.ViewModels.RoleModels
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using VacationManager.Data.Models;
    using VacationManager.Services.Mapping;

    public class RoleViewModel : IMapFrom<ApplicationRole>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int UserInRoleCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, RoleViewModel>()
                .ForMember(d => d.UserInRoleCount,
                    u => u.MapFrom(u => u.Roles.Where(r => r.RoleId == Id).Count()));
        }
    }
}
