using Microsoft.EntityFrameworkCore;
using Reservation.Domain.Models;

namespace Reservation.Infrastructure.Abstracts
{
    public interface IDataContext
    {
        DbSet<Asset> Assets { get; set; }
        DbSet<ReservationItem> ReservationItems { get; set; }
    }
}
