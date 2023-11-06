using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Status
    {
        public Status()
        {
            Donates = new HashSet<Donate>();
        }

        public int Id { get; set; }
        public string StatusName { get; set; } = null!;

        public virtual ICollection<Donate> Donates { get; set; }
    }
}
