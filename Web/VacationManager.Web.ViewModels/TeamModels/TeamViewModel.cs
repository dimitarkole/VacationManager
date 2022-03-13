namespace VacationManager.Web.ViewModels.TeamModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AutoMapper;
    using VacationManager.Data.Models;
    using VacationManager.Services.Mapping;
    using VacationManager.Web.ViewModels.ProjectModels;
    using VacationManager.Web.ViewModels.UserModels;

    public class TeamViewModel : IMapFrom<Team>//, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ProjectViewModel Project { get; set; }

        public virtual UserSmallViewModel TeamLead { get; set; }

        public int DevelopersCount { get; set; }
    }
}
