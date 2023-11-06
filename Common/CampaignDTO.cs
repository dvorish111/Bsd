using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CampaignDTO
    {
        public string Name { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime Duration { get; set; }
        public int Goul { get; set; }
    }
}
