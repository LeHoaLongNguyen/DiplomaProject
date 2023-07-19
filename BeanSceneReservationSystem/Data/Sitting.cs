using System.ComponentModel.DataAnnotations;

namespace BeanSceneReservationSystem.Data
{
    public class Sitting
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public int Capacity { get; set; }
        public int? Vacancies { get; set; } = 0;
        public Boolean Active { get; set; } = true;
        public List<Reservation> Reservations { get; set; } = new(); 
        public int SittingTypeId { get; set; }
        public SittingType SittingType { get; set; }
        public int RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}
