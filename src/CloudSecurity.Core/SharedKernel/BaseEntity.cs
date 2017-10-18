using System;
using System.Collections.Generic;
using System.Text;

namespace CloudSecurity.Core.SharedKernel
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public DateTime ModificationDate { get; set; } = DateTime.Now;

        public bool Disable { get; set; } = false;

        public bool NotRelevant { get; set; } = false;
    }
}
