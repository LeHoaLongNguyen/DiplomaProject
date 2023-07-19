using BeanSceneReservationSystem.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;


namespace BeanSceneReservationSystem.Controllers.Api.MongoDb
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
      

        //public async Task GetAll()
        //{
        //    ProductRepository productsRepository = new ProductRepository();
        //    MongoClient client = new MongoClient("mongodb://localhost:27017");

        //    var database = client.GetDatabase("mynewdb");

        //    var collection = database.GetCollection<BsonDocument>("products");

        //    var findResult = collection.Find(Builders<BsonDocument>.Filter.Empty)
        //        .ToList();
        //    // var findResult = collection.Find((p) => true).ToList();

        //    foreach (BsonDocument product in findResult)
        //    {
        //        Console.WriteLine("Product Information");
        //        Console.WriteLine("ObjectID: " + product.GetValue("_id"));
        //        Console.WriteLine("Name: " + product.GetValue("name"));
        //        Console.WriteLine("Price: " + product.GetValue("price").ToDecimal());
        //        var ingredients = product.GetValue("ingredients", new BsonArray());
        //        Console.WriteLine("Ingredients: " + ingredients);
        //    }
        //}
    }
}
