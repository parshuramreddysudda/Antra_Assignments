using Cart.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Cart.Services;

public class CartService
{
    private readonly IMongoCollection<Entities.Cart> _cartsCollection;

    public CartService(IOptions<CartDatabaseSettings> cartDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            cartDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            cartDatabaseSettings.Value.DatabaseName);

        _cartsCollection = mongoDatabase.GetCollection<Entities.Cart>(
            cartDatabaseSettings.Value.CollectionName);
    }

    public async Task<List<Entities.Cart>> GetAsync() =>
        await _cartsCollection.Find(_ => true).ToListAsync();

    public async Task<Entities.Cart?> GetAsync(string id) =>
        await _cartsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Entities.Cart newCart) =>
        await _cartsCollection.InsertOneAsync(newCart);

    public async Task UpdateAsync(string id, Entities.Cart updatedCart) =>
        await _cartsCollection.ReplaceOneAsync(x => x.Id == id, updatedCart);

    public async Task RemoveAsync(string id) =>
        await _cartsCollection.DeleteOneAsync(x => x.Id == id);
    
    public async  Task<List<Entities.Cart>> GetByUserIdAsync(string id) =>
        await _cartsCollection.Find( x => x.UserId== id).ToListAsync();
}