using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Role
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
