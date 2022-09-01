using System;
using System.Collections.Generic;

#nullable disable

namespace GInsurance.Models
{
    public partial class Detail
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string ManufacturerName { get; set; }
        public string Model { get; set; }
        public string License { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string RegistrationNumber { get; set; }
        public string EngineNumber { get; set; }
        public string ChassisNumber { get; set; }
       // public string Address { get; set; }
        public string TypeOfVehicle { get; set; }

        public virtual User User { get; set; }
    }
}
