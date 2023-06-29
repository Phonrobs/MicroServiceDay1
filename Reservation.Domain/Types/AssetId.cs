namespace Reservation.Domain.Types
{
    public class AssetId
    {
        public string Value { get; }

        public AssetId(string value)
        {
           Value = value;
        }

        public static AssetId Create()
        {
            return new AssetId(Guid.NewGuid().ToString());  
        }
    }
}
