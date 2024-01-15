using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Neighborhood
    {
        public Neighborhood()
        {
            Donates = new HashSet<Donate>();
            Donations = new HashSet<Donation>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Donate> Donates { get; set; }
        public virtual ICollection<Donation> Donations { get; set; }
    }
}
