using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string ShortDescription { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string LongDescription { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}