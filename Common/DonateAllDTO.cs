﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class DonateAllDTO
    {
         public int? Id { get; set; }
        public string? ParentTaz{ get; set; } = null!;
        public string? Name { get; set; } = null!;
        public int NumChildren { get; set; }
        public int IdStatus { get; set; }
        public string Street { get; set; } = null!;
        public double Needed { get; set; }
        public int? NumberBuilding { get; set; }
        public int IdNeighborhood { get; set; }
        public int Raised { get; set; }


    }
}
