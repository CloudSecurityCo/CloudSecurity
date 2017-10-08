using CloudSecurity.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CloudSecurity.Core.Entities
{
    [Table("User")]
    public class User : BaseEntity
    {
        [Required]
        [StringLength(60)]
        public string Login { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [Required]
        [StringLength(60)]
        public string Email { get; set; }

        public int ConfigurationOfUserSignatureId { get; set; }
        public ConfigurationOfUserSignature ConfigurationOfUserSignature { get; set; }

        public List<UserSignature> UserSignatures { get; set; }
        
    }
}
