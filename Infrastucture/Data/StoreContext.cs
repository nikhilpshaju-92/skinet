using Microsoft.EntityFrameworkCore;
using core.Entities;

namespace Infrastucture.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
    }
    
}