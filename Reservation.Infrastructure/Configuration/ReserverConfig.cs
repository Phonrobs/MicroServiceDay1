using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Reservation.Domain.Models;
using Reservation.Infrastructure.Converters;

namespace Reservation.Infrastructure.Configuration
{
    public class ReserverConfig : IEntityTypeConfiguration<Reserver>
    {
        public void Configure(EntityTypeBuilder<Reserver> builder)
        {
            builder.ToTable("Reserver")
               .HasKey(x => x.ReserverId)
               .IsClustered();

            builder.Property(x => x.ReserverId)
                .HasConversion<ReserverIdConverter>()
                .HasMaxLength(255);

            builder.Property(x => x.EmailAddress)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasIndex(x => x.EmailAddress)
                .IsUnique();

            builder.HasMany(x => x.ReservationItems)
               .WithOne(x => x.Reserver)
               .HasForeignKey(x => x.ReserverId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
