namespace BeanSceneReservationSystem.MongoDbApi.Models
{
    public interface IOrderStoreDatabaseSettings
    {
        string OrderCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
