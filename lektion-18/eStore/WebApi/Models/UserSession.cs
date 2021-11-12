using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class UserSession
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string SessionToken { get; set; }

        public virtual User User { get; set; }
    }
}
