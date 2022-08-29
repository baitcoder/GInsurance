using System;
using System.Collections.Generic;

#nullable disable

namespace GInsurance.Models
{
    public partial class PolicyTable
    {
        public PolicyTable()
        {
            Claims = new HashSet<Claim>();
            Renewals = new HashSet<Renewal>();
        }

        public int PolicyId { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public DateTime EndDate { get; set; }
        public int? PlanId { get; set; }
        public int? UserId { get; set; }

        public virtual Plan Plan { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Claim> Claims { get; set; }
        public virtual ICollection<Renewal> Renewals { get; set; }
    }
}
