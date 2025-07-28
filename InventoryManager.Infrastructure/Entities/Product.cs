using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
    public Guid StoreId { get; set; }
    public Store Store { get; set; }
    public virtual ICollection<ProductSale> ProductSales { get; set; }
}

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
        .HasColumnName("name");

        builder.Property(x => x.Code)
        .HasColumnName("code");

        builder.Property(x => x.Price)
        .HasColumnName("price")
        .HasColumnType("decimal(18,2)");

        builder.Property(x => x.Amount)
        .HasColumnName("amount");

        builder.Property(x => x.StoreId)
        .HasColumnName("store_id");
    }
}