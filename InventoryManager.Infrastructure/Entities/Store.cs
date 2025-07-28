using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class Store
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Cnpj { get; set; }
    public string Email { get; set; }
    public string Telephone { get; set; }
    public string State { get; set; }
    public string City { get; set; }

    public virtual ICollection<UserStore> UserStores { get; set; }
}

public class StoreConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.ToTable("stores");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Cnpj)
            .HasColumnName("cnpj")
            .HasMaxLength(20);

        builder.Property(x => x.Email)
            .HasColumnName("email")
            .HasMaxLength(100);

        builder.Property(x => x.Telephone)
            .HasColumnName("telephone")
            .HasMaxLength(20);

        builder.Property(x => x.State)
            .HasColumnName("state")
            .HasMaxLength(2);

        builder.Property(x => x.City)
            .HasColumnName("city")
            .HasMaxLength(100);
    }
}