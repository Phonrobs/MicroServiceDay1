namespace Reservation.Domain.Types
{
    public class ApproverId
    {
        public ApproverId(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static ApproverId Create()
        {
            return new ApproverId(Guid.NewGuid().ToString());
        }
    }
}
