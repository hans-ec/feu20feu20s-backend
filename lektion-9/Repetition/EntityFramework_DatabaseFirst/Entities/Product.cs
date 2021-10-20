using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EntityFramework_DatabaseFirst.Entities
{
    public partial class Product
    {
        [Key]
        [StringLength(15)]
        public string ArticleNumber { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }
        [Required]
        [StringLength(200)]
        public string Vendor { get; set; }
        public int CategoryId { get; set; }
        public bool? InStock { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Products")]
        public virtual Category Category { get; set; }
    }
}
