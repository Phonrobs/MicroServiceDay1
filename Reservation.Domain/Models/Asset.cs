using Reservation.Domain.Exceptions;
using Reservation.Domain.Types;

namespace Reservation.Domain.Models
{
    public class Asset
    {
        public AssetId AssetId { get; private set; }
        public string Name { get; private set; }
        public int ItemInStockCount { get; private set; }
        public int AllItemCount { get; private set; }

        public List<ReservationItem> ReservationItems { get; set; }

        public Asset(AssetId assetId, string name, int itemInStockCount, int allItemCount)
        {
            AssetId = assetId;
            Name = name;
            ItemInStockCount = itemInStockCount;
            AllItemCount = allItemCount;
        }

        public void Update(Asset updatingAsset)
        {
            // Guard clause
            if (updatingAsset.ItemInStockCount > updatingAsset.AllItemCount)
            {
                throw new InvalidStockCountException();
            }

            AssetId = updatingAsset.AssetId;
            Name = updatingAsset.Name;
            ItemInStockCount = updatingAsset.ItemInStockCount;
            AllItemCount = updatingAsset.AllItemCount;
        }
    }
}
