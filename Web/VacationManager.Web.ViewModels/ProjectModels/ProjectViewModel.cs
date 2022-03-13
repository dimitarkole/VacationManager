using System;
using System.Collections.Generic;
using System.Text;
using VacationManager.Data.Models;
using VacationManager.Services.Mapping;

namespace VacationManager.Web.ViewModels.ProjectModels
{
    public class ProjectViewModel : IMapFrom<Project>
    { 
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
