namespace Reservation.Domain.Exceptions
{
    internal class InvalidStockCountException
        : Exception
    {
        public InvalidStockCountException() : base("ค่าครุภัณฑ์ที่คงเหลือใน Stock (ItemInStockCount) ห้ามมากกว่าจำนวนครุภัณฑ์ทั้งหมด (AllItemCount)")
        {
        }
    }
}
