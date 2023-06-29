using Reservation.Domain.Types;

namespace Reservation.Domain.Models
{
    public class Reserver
    {
        public ReserverId ReserverId { get; set; }
        public string EmailAddress { get; set; }
        public List<ReservationItem> ReservationItems { get; set; }
    }
}
