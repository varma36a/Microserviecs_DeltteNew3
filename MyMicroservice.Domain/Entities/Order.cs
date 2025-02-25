
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyMicroservice.Domain.Entities;

public class Order
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    public string ProductId { get; set; } = null!;
    public int Quantity { get; set; }

    public Order(string productId, int quantity)
    {
        Id = ObjectId.GenerateNewId().ToString();
        ProductId = productId;
        Quantity = quantity;
    }
}
