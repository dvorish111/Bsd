﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ImagesDTO { 
        public int Id { get; set; }
        public string FileName { get; set; }
       // public byte[]? FileData { get; set; }
        public string ContentType { get; set; }
        public int FileSize { get; set; }
        //public DateTime CreatedAt { get; set; }
    }

}
