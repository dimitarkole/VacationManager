namespace VacationManager.Data.Models
{
    using System.Collections.Generic;

    using VacationManager.Data.Models;

    public class Team : BaseEntity
    {
        public Team()
        {
            this.Developers = new HashSet<ApplicationUser>();
        }

        public string Name { get; set; }

        public int? ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public string? TeamLeadId { get; set; }

        public virtual ApplicationUser TeamLead { get; set; }

        public virtual ICollection<ApplicationUser> Developers { get; set; }
    }
}
