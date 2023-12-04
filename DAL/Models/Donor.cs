using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Donor
    {
        public Donor()
        {
            Donations = new HashSet<Donation>();
        }

        public int Id { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string City { get; set; } = null!;
        public string? Street { get; set; }
        public int? ZipCode { get; set; }

        public virtual ICollection<Donation> Donations { get; set; }
    }
}
