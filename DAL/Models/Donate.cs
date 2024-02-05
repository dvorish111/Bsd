using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Donate
    {
        public Donate()
        {
            Donations = new HashSet<Donation>();
        }

        public int Id { get; set; }
        public int ParentTaz { get; set; }
        public string Name { get; set; } = null!;
        public int NumChildren { get; set; }
        public int IdStatus { get; set; }
        public string Street { get; set; } = null!;
        public double Needed { get; set; }
        public int NumberBuilding { get; set; }
        public int IdNeighborhood { get; set; }
        public int Raised { get; set; }

        public virtual Neighborhood IdNeighborhoodNavigation { get; set; } = null!;
        public virtual Status IdStatusNavigation { get; set; } = null!;
        public virtual ICollection<Donation> Donations { get; set; }
    }
}
