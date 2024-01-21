using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class DonationDTO
    {
        public int Id { get; set; }
        public bool? IsAnonymous { get; set; }
        public string? Dedication { get; set; }
        public int Amount { get; set; }
        public int? IdDonated { get; set; }
        public int IdDonor { get; set; }
        public int IdNeighborhoods { get; set; }
        public virtual DonateDTO? IdDonatedNavigation { get; set; }
        public virtual DonorDTO IdDonorNavigation { get; set; } = null!;
        public virtual NeighborhoodDTO? IdNeighborhoodNavigation { get; set; }
    }
}
