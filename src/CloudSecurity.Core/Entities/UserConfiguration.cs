using System;
using System.Collections.Generic;
using System.Text;

namespace CloudSecurity.Core.Entities
{
    public class UserConfiguration: FileModel
    {
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
