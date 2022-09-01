using System;
using System.Collections.Generic;
using GInsurance.Models.ViewModel;

#nullable disable

namespace GInsurance.Models
{
    public partial class User
    {
        public User()
        {
            Claims = new HashSet<Claim>();
            Details = new HashSet<Detail>();
           // PaymentTables = new HashSet<PaymentTable>();
            PolicyTables = new HashSet<PolicyTable>();
          //  Renewals = new HashSet<Renewal>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Contact { get; set; }
        public string Password { get; set; }
       
        public virtual ICollection<Claim> Claims { get; set; }
        public virtual ICollection<Detail> Details { get; set; }
       // public virtual ICollection<PaymentTable> PaymentTables { get; set; }
        public virtual ICollection<PolicyTable> PolicyTables { get; set; }
        //public virtual ICollection<Renewal> Renewals { get; set; }
    }
}
