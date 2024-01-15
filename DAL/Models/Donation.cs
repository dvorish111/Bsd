using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Donation
    {
        public int Id { get; set; }
        public bool? IsAnonymous { get; set; }
        public string? Dedication { get; set; }
        public string? Quetel { get; set; }
        public int Amount { get; set; }
        public int? NumPayments { get; set; }
        public int? IdDonated { get; set; }
        public int IdDonor { get; set; }
        public int IdNeighborhoods { get; set; }

        public virtual Donate? IdDonatedNavigation { get; set; }
        public virtual Donor IdDonorNavigation { get; set; } = null!;
        public virtual Neighborhood IdNeighborhoodsNavigation { get; set; } = null!;
    }
}
