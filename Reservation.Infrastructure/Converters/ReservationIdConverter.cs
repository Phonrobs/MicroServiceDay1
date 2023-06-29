using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reservation.Domain.Types;

namespace Reservation.Infrastructure.Converters
{
    public class ReservationIdConverter : ValueConverter<ReservationId, string>
    {
        public ReservationIdConverter() : base(v => v.Value, v => new(v))
        {
        }
    }
}
