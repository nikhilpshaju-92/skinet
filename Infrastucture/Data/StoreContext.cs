using Microsoft.EntityFrameworkCore;
using core.Entities;
using System.Reflection;

namespace Infrastucture.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductBrand> ProductBrand { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //   modelBuilder.Entity<Product>()
        //          .HasMany(dm => dm.ProductBrandId)
        //          .WithOne()
        //         .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
    }
    
}