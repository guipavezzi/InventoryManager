using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProductSale
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    public Guid SaleId { get; set; }
    public Sale Sale { get; set; }

    public int Amount { get; set; }
    public decimal Price { get; set; }
}

public class ProductSaleConfiguration : IEntityTypeConfiguration<ProductSale>
{
    public void Configure(EntityTypeBuilder<ProductSale> builder)
    {
        builder.ToTable("products_sale");
        builder.HasKey(ps => new { ps.ProductId, ps.SaleId });

        builder.Property(x => x.ProductId)
            .HasColumnName("product_id");

        builder.Property(x => x.SaleId)
            .HasColumnName("sale_id");

        builder.Property(x => x.Amount)
            .HasColumnName("amount");

        builder.Property(x => x.Price)
            .HasColumnName("price")
            .HasColumnType("decimal(18,2)");

        builder.HasOne(ps => ps.Product)
            .WithMany(p => p.ProductSales)
            .HasForeignKey(ps => ps.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ps => ps.Sale)
            .WithMany(s => s.ProductSale)
            .HasForeignKey(ps => ps.SaleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}