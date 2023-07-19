using BeanSceneReservationSystem.Data;

namespace BeanSceneReservationSystem.Areas.Staff.Models
{
    public class ReservationSourceAndStatusVM
    {
        public int ReservationId { get; set; }
        public string Name { get; set; }
        public int ReservationSourceId { get; set; }
        public int ReservationStatusId { get; set; }

    }
}
