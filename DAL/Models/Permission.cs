using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Permission
    {
        public int Id { get; set; }
        public string ManagerName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Email { get; set; }
    }
}
