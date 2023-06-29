namespace Reservation.Domain.Types
{
    public class ReservationId
    {
        public ReservationId(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static ReservationId Create()
        {
            return new ReservationId(Guid.NewGuid().ToString());
        }
    }
}
