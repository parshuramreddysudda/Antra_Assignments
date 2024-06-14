using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cart.Entities;

public class Cart
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; } = null!;
        
    public string UserId { get; set; } = null!;
    public List<CartItem> Items { get; set; } = new List<CartItem>();
}

public class CartItem
{
    public string ProductId { get; set; } = null!;
    public int Quantity { get; set; }
}