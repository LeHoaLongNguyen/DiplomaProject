using BeanSceneReservationSystem.MongoDbApi.Models;
using MongoDB.Driver;
using NuGet.Configuration;

namespace BeanSceneReservationSystem.MongoDbApi.Services
{
    public class OrderService : IOrderService
    {
        private IMongoCollection<Order> _orders;
        public OrderService(IOrderStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _orders = database.GetCollection<Order>(settings.OrderCollectionName);
        }
        public Order Create(Order order)
        {
            _orders.InsertOne(order);
            return order;
        }


        public List<Order> Get()
        {
            return _orders.Find(Order => true).ToList();
        }

        public Order Get(string id)
        {
            return _orders.Find(order => order.Id == id).FirstOrDefault();
        }

        public void Update(string id, Order order)
        {
            _orders.ReplaceOne(order => order.Id == id, order);
        }
        public void Delete(string id)
        {
            _orders.DeleteOne(order => order.Id == id);
        }
    }
}
