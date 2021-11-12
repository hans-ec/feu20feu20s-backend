using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class UserHash
    {
        [Key]
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] Salt { get; set; }

        public virtual User User { get; set; }
    }
}
