using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class DonorAllDTO
    {
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Phone { get; set; }
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
       // public int ZipCode { get; set; }
    }
}
