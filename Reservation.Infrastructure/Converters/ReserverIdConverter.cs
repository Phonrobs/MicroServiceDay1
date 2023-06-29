using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reservation.Domain.Types;

namespace Reservation.Infrastructure.Converters
{
    public class ReserverIdConverter : ValueConverter<ReserverId, string>
    {
        public ReserverIdConverter() : base(v => v.Value, v => new(v))
        {
        }
    }
}
