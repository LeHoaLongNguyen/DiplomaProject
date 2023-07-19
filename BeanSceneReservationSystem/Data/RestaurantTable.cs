namespace BeanSceneReservationSystem.Data
{
    public class RestaurantTable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int AreaID { get; set; }

        public double? PosX { get; set; }
        public double? PosY { get; set; }

        // Navigation properties
        public Area? Area { get; set; }
        public List<ReservationTable> ReservationTables { get; set; }

    }
}
