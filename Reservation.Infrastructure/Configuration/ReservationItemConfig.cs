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
            builder.ToTable("ReservationItem");
            builder.HasKey(x => x.ReservationId);

            builder.HasIndex(x => x.AssetId);
            builder.HasIndex(x => x.ReserverId);

            builder.Property(x=>x.Status)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.AssetId)
                .HasConversion<AssetIdConverter>();
        }
    }
}
