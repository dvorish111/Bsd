using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Campaign
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Goul { get; set; }
    }
}
