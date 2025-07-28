using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserStore
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid StoreId { get; set; }
    public Store Store { get; set; }
}

public class UserStoreConfiguration : IEntityTypeConfiguration<UserStore>
{
    public void Configure(EntityTypeBuilder<UserStore> builder)
    {
        builder.ToTable("user_store");

        builder.HasKey(us => new { us.UserId, us.StoreId });

        builder.Property(us => us.UserId)
            .HasColumnName("user_id");

        builder.Property(us => us.StoreId)
            .HasColumnName("store_id");
    }
}