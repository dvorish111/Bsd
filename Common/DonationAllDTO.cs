﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class DonationAllDTO
    {
        public int Id { get; set; }
        public bool? IsAnonymous { get; set; }
        public string? Dedication { get; set; }
        public string? Quetel { get; set; }
        public int Amount { get; set; }
        public int? IdDonated { get; set; }
        public int? IdDonor { get; set; }
        public int IdNeighborhood { get; set; }
        public int? NumPayments { get; set; }
    }
}
