using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class UserRole
    {
        [Key]
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public int RoleId { get; set; }


        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
        
    }
}
