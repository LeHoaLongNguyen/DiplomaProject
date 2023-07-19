using BeanSceneReservationSystem.Data;

namespace BeanSceneReservationSystem.Models
{
    public class SittingCreateVM
    {
        public Sitting Sitting { get; set; }
        public string Name { get; set; }

        public int Capacity { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int RepeatNumber { get; set; }
    }
}
