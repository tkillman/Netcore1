using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netcore.Data.DataModels
{
    //<summary>
    //사용자소유권한
    public class User
    {   [Key, StringLength(50), Column(TypeName = "varchar(50)")]
        public string UserId { get; set; }

        [Required, StringLength(100), Column(TypeName ="nvarchar(100)")]
        public string UserName { get; set; }

        [Required, StringLength(320), Column(TypeName = "varchar(320)")]
        public string UserEmail { get; set; }

        [Required, StringLength(130), Column(TypeName = "nvarchar(130)")]
        public string Password { get; set; }

        [Required]
        public bool IsMembershipWidthdrawn { get; set; }

        [Required]
        public DateTime JoinedUtcDate { get; set; }

        //FK 지정
        [ForeignKey("UserId")]
         public virtual ICollection<UserRolesByUser> UserRolesByUsers { get; set; }

       
    }
}
