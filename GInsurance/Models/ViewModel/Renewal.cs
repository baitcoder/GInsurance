using System;
using System.Collections.Generic;

#nullable disable

namespace GInsurance.Models.ViewModel
{
    public partial class Renewal
    {
        public int RenewId { get; set; }
        public int? UserId { get; set; }
        public int? PolicyId { get; set; }

        //public virtual PolicyTable Policy { get; set; }
        //public virtual User User { get; set; }
    }
}
