using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class ContextDB : DbContext
{
    public ContextDB(DbContextOptions<ContextDB> options) : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductSale> ProductSales { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserStore> UserStores { get; set; }
    public DbSet<RefreshToken> RefreshTokens{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ProductSaleConfiguration());
        modelBuilder.ApplyConfiguration(new SaleConfiguration());
        modelBuilder.ApplyConfiguration(new StoreConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserStoreConfiguration());
        modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());
    }
}

//CLASSE PARA FAZER A MIGRATION
// public class ContextDBFactory : IDesignTimeDbContextFactory<ContextDB>
// {
//     public ContextDB CreateDbContext(string[] args)
//     {
//         var optionsBuilder = new DbContextOptionsBuilder<ContextDB>();
//         optionsBuilder.UseSqlServer("YOUR_CONNECTION");

//         return new ContextDB(optionsBuilder.Options);
//     }
// }