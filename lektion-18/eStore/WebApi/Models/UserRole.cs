using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
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
