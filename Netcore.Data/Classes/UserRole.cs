using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Netcore.Data.Classes
{
    public class UserRole
    {
        [Key, StringLength(50), Column(TypeName = "varchar(50)")]
        public string RoleId { get; set; }

        [Required, StringLength(100), Column(TypeName = "nvarchar(100)")]
        public string RoleName { get; set; }

        [Required]
        public byte RolePriority { get; set; }

        [Required]
        public System.DateTime ModifiedUtcDate { get; set; }

        [ForeignKey("RoleId")]
        public virtual ICollection<UserRolesByUser> UserRolesByUsers { get; set; }
    }
}
