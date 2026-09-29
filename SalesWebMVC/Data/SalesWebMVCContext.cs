using Microsoft.EntityFrameworkCore;

namespace SalesWebMVC.Models
{
    public class SalesWebMVCContext(DbContextOptions<SalesWebMVCContext> options) : DbContext(options)
    {
        public DbSet<Department> Department { get; set; } = default!;
        public DbSet<Seller> Seller { get; set; } = default!;
        public DbSet<SalesRecord> SalesRecord { get; set; } = default!;
    }
}

