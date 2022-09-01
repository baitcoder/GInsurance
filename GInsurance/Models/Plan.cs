using System;
using System.Collections.Generic;

#nullable disable

namespace GInsurance.Models
{
    public partial class Plan
    {
        public Plan()
        {
            Claims = new HashSet<Claim>();
            PaymentTables = new HashSet<PaymentTable>();
            PolicyTables = new HashSet<PolicyTable>();
        }

        public int PlanId { get; set; }
        public string Type { get; set; }
        public int? Term { get; set; }
        public int? Amount { get; set; }
        public int? UserId { get; set; }

        public virtual ICollection<Claim> Claims { get; set; }
        public virtual ICollection<PaymentTable> PaymentTables { get; set; }
        public virtual ICollection<PolicyTable> PolicyTables { get; set; }
    }
}
