using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
           
        public string Description { get; set; }
        
        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public int SubCategoryId { get; set; }

        public virtual SubCategory SubCategory { get; set; }

    }
}
