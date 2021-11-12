using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class UserSession
    {
        [Key]
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string SessionToken { get; set; }

        public virtual User User { get; set; }
    }
}
