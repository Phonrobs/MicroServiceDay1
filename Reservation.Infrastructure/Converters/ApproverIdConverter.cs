using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reservation.Domain.Types;

namespace Reservation.Infrastructure.Converters
{
    public class ApproverIdConverter : ValueConverter<ApproverId, string>
    {
        public ApproverIdConverter() : base(v => v.Value, v => new(v))
        {
        }
    }
}
