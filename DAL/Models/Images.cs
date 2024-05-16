using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Images
    {
        public int Id { get; set; }
        public string FileName { get; set; } = null!;
        public byte[]? FileData { get; set; }
        public string ContentType { get; set; } = null!;
        public int FileSize { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
