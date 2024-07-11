using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ImagesSaveDTO
    {
        /*        public int Id { get; set; }
                public string FileName { get; set; }
                public string ContentType { get; set; }
                public int FileSize { get; set; }*/



        public int Id { get; set; }
        public string FileName { get; set; } = null!;
        public byte[]? FileData { get; set; }
        public string? ContentType { get; set; }
        public long? Size { get; set; }
        /* public int Id { get; set; }
         public string FileName { get; set; } = null!;
         public string FileData { get; set; } = null!; // Base64 encoded string
         public string ContentType { get; set; } = null!;
         public long Size { get; set; }*/
    }

}
