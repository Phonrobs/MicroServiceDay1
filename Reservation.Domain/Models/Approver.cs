using Reservation.Domain.Types;

namespace Reservation.Domain.Models;

public class Approver
{
    public ApproverId ApproverId { get; set; }
    public string EmailAddress { get; set; }
    public List<ReservationItem> ReservationItems { get; set; }
}
