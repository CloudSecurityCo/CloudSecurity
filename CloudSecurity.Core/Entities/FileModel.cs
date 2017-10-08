using CloudSecurity.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudSecurity.Core.Entities
{
    public class FileModel : BaseEntity
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
    }
}
