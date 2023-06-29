using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Reservation.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Reservation.Infrastructure.Converters;

namespace Reservation.Infrastructure.Configuration
{
    public class ReservationItemConfig : IEntityTypeConfiguration<ReservationItem>
    {
        public void Configure(EntityTypeBuilder<ReservationItem> builder)
        {
            builder.ToTable("ReservationItem")
           .HasKey(x => x.ReservationId)
           .IsClustered();

            builder.Property(x => x.ReservationId)
                .HasConversion<ReservationIdConverter>()
                .HasMaxLength(255);

            builder.Property(x => x.AssetId)
               .HasConversion<AssetIdConverter>()
               .HasMaxLength(255);

            builder.Property(x => x.ReserverId)
                .HasConversion<ReserverIdConverter>()
                .HasMaxLength(255);

            builder.HasIndex(x => x.AssetId);
            builder.HasIndex(x => x.ReserverId);
        }
    }
}
