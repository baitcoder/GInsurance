using System;
using System.Collections.Generic;

#nullable disable

namespace GInsurance.Models
{
    public partial class Detail
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string DrivingLicense { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string RegNumber { get; set; }
        public int EngineNumber { get; set; }
        public int ChassisNumber { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }

        public virtual User User { get; set; }
    }
}
