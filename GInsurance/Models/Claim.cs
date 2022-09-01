using System;
using System.Collections.Generic;

#nullable disable

namespace GInsurance.Models
{
    public partial class Claim
    {
        public int ClaimNo { get; set; }
        public DateTime ClaimDate { get; set; }
        public string Reason { get; set; }
        public int Amount { get; set; }
        public bool ApproveStatus { get; set; }
        public int? UserId { get; set; }
       
        //public virtual Plan Plan { get; set; }
        //public virtual PolicyTable Policy { get; set; }
        public virtual User User { get; set; }
    }
}
