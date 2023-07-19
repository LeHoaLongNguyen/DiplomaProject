using BeanSceneReservationSystem.Data;

namespace BeanSceneReservationSystem.Models
{
    public class SittingVM
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int Capacity { get; set; }

        public Boolean Active { get; set; } = true;

        public int SittingTypeId { get; set; }
        public SittingType SittingType { get; set; }
        public int RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}
