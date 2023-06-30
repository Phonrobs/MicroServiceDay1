using Microsoft.EntityFrameworkCore;
using Reservation.Domain.Models;

namespace Reservation.Infrastructure.Abstracts
{
    public interface IDataContext
    {
        DbSet<Asset> Assets { get; set; }
        DbSet<ReservationItem> ReservationItems { get; set; }
        DbSet<Reserver> Reservers { get; set; }
        DbSet<Approver> Approvers { get; set; }

        Task SaveChangeAsync(CancellationToken cancellationToken);
    }
}
