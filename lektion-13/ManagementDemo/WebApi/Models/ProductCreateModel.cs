using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class ProductCreateModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; } = "";

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; } = "";

        [Required]
        public int SubCategoryId { get; set; }
    }
}
