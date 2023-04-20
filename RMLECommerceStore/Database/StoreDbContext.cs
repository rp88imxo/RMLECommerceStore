using Microsoft.EntityFrameworkCore;
using RMLECommerceStore.Models;

namespace RMLECommerceStore.Database
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();

        public StoreDbContext(DbContextOptions<StoreDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }
    }
}
