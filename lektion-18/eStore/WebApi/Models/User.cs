using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class User
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        public virtual UserHash UserHash { get; set; }
        public virtual ICollection<UserSession> UserSessions { get; set; }
        public virtual UserRole UserRole {get;set;}
    }
}
