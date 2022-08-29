using System;
using System.Collections.Generic;

#nullable disable

namespace GInsurance.Models
{
    public partial class PaymentTable
    {
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public int? PlanId { get; set; }
        public int? UserId { get; set; }

        public virtual Plan Plan { get; set; }
        public virtual User User { get; set; }
    }
}
