using EntityFramework_CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_CodeFirst.Data
{
    public class EfCodeFirstContext : DbContext
    {
        public EfCodeFirstContext(DbContextOptions<EfCodeFirstContext> options) : base(options)
        {

        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

    }
}
