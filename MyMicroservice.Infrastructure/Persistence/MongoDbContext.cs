using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MyMicroservice.Domain.Entities;
using MyMicroservice.Infrastructure.Settings;

namespace MyMicroservice.Infrastructure.Persistence;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        _database = client.GetDatabase(settings.Value.DatabaseName);
    }

    public IMongoCollection<Order> Orders => _database.GetCollection<Order>("Orders");
}
