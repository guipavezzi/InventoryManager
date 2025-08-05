using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RefreshToken
{
       public Guid Id { get; set; }
       public string Token { get; set; } = string.Empty;
       public DateTime Expires { get; set; }
       public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
       public bool IsRevoked { get; set; } = false;
       public Guid UserId { get; set; }
       public User User { get; set; } = null!;
}

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
       public void Configure(EntityTypeBuilder<RefreshToken> builder)
       {
              builder.ToTable("refresh_token");
              builder.HasKey(x => x.Id);

              builder.Property(x => x.Token)
                     .HasColumnName("token")
                     .IsRequired();

              builder.Property(x => x.Expires)
                     .HasColumnName("expires");

              builder.Property(x => x.CreatedAt)
                     .HasColumnName("created_at");

              builder.Property(x => x.IsRevoked)
                     .HasColumnName("is_revoked");

              builder.Property(x => x.UserId)
                     .HasColumnName("user_id");

              builder.HasOne(rt => rt.User)
                     .WithMany()
                     .HasForeignKey(rt => rt.UserId)
                     .IsRequired();
       }
}