using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Domain.Models;
using Reservation.Infrastructure.Converters;

namespace Reservation.Infrastructure.Configuration
{
    public class AssetConfig : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.ToTable("Asset");
            builder.HasKey(x => x.AssetId);

            builder.HasIndex(x => x.Name).IsUnique();

            builder.Property(x => x.AssetId)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(500)
                .IsRequired();

            builder.HasMany(x=>x.ReservationItems)
                .WithOne(x => x.Asset)
                .HasForeignKey(x => x.AssetId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.AssetId)
                .HasConversion<AssetIdConverter>();

            builder.Property(x => x.AssetId)
               .HasConversion<AssetIdConverter>();
        }
    }
}
