namespace BeanSceneReservationSystem.Data
{
    public class Area
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public List<RestaurantTable> RestaurantTables { get; set; } = new();

    }
}
