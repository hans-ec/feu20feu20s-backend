using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace WebApi.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }        
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserHash> Hashes { get; set; }
        public virtual DbSet<UserSession> Sessions { get; set; }
    }
}
