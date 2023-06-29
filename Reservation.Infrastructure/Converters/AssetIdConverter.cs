using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reservation.Domain.Types;

namespace Reservation.Infrastructure.Converters;

public class AssetIdConverter : ValueConverter<AssetId, string>
{
    public AssetIdConverter() : base(v => v.Value, v => new AssetId(v))
    {
    }
}