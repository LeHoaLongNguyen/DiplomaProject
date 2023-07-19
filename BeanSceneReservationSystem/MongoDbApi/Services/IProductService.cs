using BeanSceneReservationSystem.MongoDbApi.Models;

namespace BeanSceneReservationSystem.MongoDbApi.Services
{
    public interface IProductService
    {
        List<Product> Get();
        Product Get(string id);
        Product Create(Product product);
        void Update(string id, Product product);
        void Delete(string id);
    }
}
