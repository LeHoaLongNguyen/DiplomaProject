using BeanSceneReservationSystem.Data;

namespace BeanSceneReservationSystem.Areas.Staff.Models
{
    public class UpdateReservationsViewModel
    {
        public List<Reservation> Reservations { get; set; }
        public List<ReservationSource> ReservationsSource { get; set; }
        public List<ReservationStatus> ReservationsStatus { get; set; }
    }
}
