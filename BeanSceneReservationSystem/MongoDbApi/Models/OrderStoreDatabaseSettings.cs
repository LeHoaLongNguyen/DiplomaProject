namespace BeanSceneReservationSystem.MongoDbApi.Models
{
    public class OrderStoreDatabaseSettings : IOrderStoreDatabaseSettings
    {
        public string OrderCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
