using Microsoft.EntityFrameworkCore;
using UltraGreateDivanShop.Database.EntityTypeConfigurations;
using UltraGreateDivanShop.Domain;
using UltraGreateDivanShop.Domain.Users;

namespace UltraGreateDivanShop.Database;

public class DivanShopContext(DbContextOptions<DivanShopContext> options) : DbContext(options)
{
    public DbSet<ProductImg> ProductImgs { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<WhishList> WhishLists { get; set; }
    public new DbSet<ApplicationUser> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}