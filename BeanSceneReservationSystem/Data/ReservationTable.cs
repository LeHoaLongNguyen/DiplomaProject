namespace BeanSceneReservationSystem.Data
{
    public class ReservationTable
    {
        public int Id { get; set; }
        public int RestaurantTableId { get; set; }
        public RestaurantTable RestaurantTable { get; set; }

        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}
