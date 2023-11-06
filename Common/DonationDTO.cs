using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class DonationDTO
    {
        public bool? IsAnonymous { get; set; }
        public string? Dedication { get; set; }
        public int Amount { get; set; }
        public int IdDonated { get; set; }
        public int IdDonor { get; set; }
    }
}
