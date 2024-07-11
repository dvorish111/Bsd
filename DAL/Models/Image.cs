using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Image
    {
        public int Id { get; set; }
        public string FileName { get; set; } = null!;
        public byte[]? FileData { get; set; }
        public string? ContentType { get; set; }
        public long? Size { get; set; }
    }
}
