using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class User1
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string UserGmail { get; set; } = null!;
        public string UserGmailP { get; set; } = null!;
    }
}
