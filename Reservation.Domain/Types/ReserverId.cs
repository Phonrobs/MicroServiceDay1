namespace Reservation.Domain.Types
{
    public class ReserverId
    {
        public ReserverId(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static ReserverId Create()
        {
            return new ReserverId(Guid.NewGuid().ToString());
        }
    }
}
