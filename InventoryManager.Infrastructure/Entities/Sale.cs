using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class Sale
{
    public Guid Id { get; set; }
    public DateTime DateSale { get; set; }
    public Guid StoreId { get; set; }
    public Store Store { get; set; }
    public decimal TotalValue { get; set; }
    public virtual ICollection<ProductSale> ProductSale { get; set; }
}

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("sales");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.DateSale)
        .HasColumnName("date_sale");

        builder.Property(x => x.StoreId)
        .HasColumnName("store_id");

        builder.Property(x => x.TotalValue)
        .HasColumnName("total_value")
        .HasColumnType("decimal(18,2)");
    }
}