using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Reservation.Domain.Models;
using Reservation.Infrastructure.Converters;

namespace Reservation.Infrastructure.Configuration
{
    public class ApproverConfig : IEntityTypeConfiguration<Approver>
    {
        public void Configure(EntityTypeBuilder<Approver> builder)
        {
            builder.ToTable("Approver")
                .HasKey(x => x.ApproverId)
                .IsClustered();

            builder
                .Property(x => x.ApproverId)
                .HasConversion<ApproverIdConverter>()
                .HasMaxLength(255);

            builder.Property(x => x.EmailAddress)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasIndex(x => x.EmailAddress)
                .IsUnique();

            builder.HasMany(x => x.ReservationItems)
               .WithOne(x => x.Approver)
               .HasForeignKey(x => x.ApproverId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
