using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_CodeFirst.Entities
{
    public class Product
    {
        [Key]
        [StringLength(15)]
        public string ArticleNumber { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        [Required]
        [StringLength(200)]
        public string Vendor { get; set; }
        
        
        public virtual Category Category { get; set; }


    }
}
