using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BeanSceneReservationSystem.MongoDbApi.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("price")]
        public decimal Price { get; set; }
        [BsonElement("quantity")]
        public int Quantity { get; set; } = 0;
        [BsonElement("ingredients")]
        public string[] Ingredients { get; set; }


    }
}
