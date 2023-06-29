using Reservation.Domain.Types;

namespace Reservation.Domain.Models
{
    public class ReservationItem
    {
        public ReservationId ReservationId { get; private set; }
        public AssetId AssetId { get; private set; }
        public ReserverId ReserverId { get; private set; }
        public ApproverId ApproverId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Status { get; private set; }
        public string Note { get; private set; }

        public Asset Asset { get; set; }
        public Reserver Reserver { get; set; }
        public Approver Approver { get; set; }

        public ReservationItem(ReservationId reservationId, AssetId assetId, ReserverId reserverId, ApproverId approverId, DateTime startDate, DateTime endDate, string status, string note)
        {
            ReservationId = reservationId;
            AssetId = assetId;
            ReserverId = reserverId;
            ApproverId = approverId;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
            Note = note;
        }
    }
}
