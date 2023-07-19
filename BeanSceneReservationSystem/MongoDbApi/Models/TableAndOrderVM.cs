using BeanSceneReservationSystem.Data;

namespace BeanSceneReservationSystem.MongoDbApi.Models
{
    public class TableAndOrderVM
    {
        public List<RestaurantTable> RestaurantTable { get; set; }
        public List<Order> Orders { get; set; }
    }
}
