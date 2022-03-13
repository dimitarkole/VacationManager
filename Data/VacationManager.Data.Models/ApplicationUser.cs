// ReSharper disable VirtualMemberCallInConstructor
namespace VacationManager.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.AspNetCore.Identity;
    using VacationManager.Data.Common.Models;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.LedTeams = new HashSet<Team>();
            this.PaidTimeOffRequests = new HashSet<PaidTimeOff>();
            this.UnpaidTimeOffRequests = new HashSet<UnpaidTimeOff>();
            this.SickTimeOffRequests = new HashSet<SickTimeOff>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? TeamId { get; set; }

        public virtual Team Team { get; set; }

        public virtual ICollection<Team> LedTeams { get; set; }

        public virtual ICollection<PaidTimeOff> PaidTimeOffRequests { get; set; }

        public virtual ICollection<UnpaidTimeOff> UnpaidTimeOffRequests { get; set; }

        public virtual ICollection<SickTimeOff> SickTimeOffRequests { get; set; }
    }
}
