using BeanSceneReservationSystem.Data;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BeanSceneReservationSystem.MongoDbApi.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }


        [BsonElement("products")]
        public List<Product> Products { get; set; }
        [BsonElement("tableid")]
        public int TableId { get; set; }
        [BsonElement("tablename")]
        public string TableName { get; set; }
        [BsonElement("areaid")]
        public int AreaId { get; set; }
        [BsonElement("areaname")]
        public string AreaName { get; set; }
        [BsonElement("totalprice")]
        public decimal TotalPrice { get; set; }


    }
}
