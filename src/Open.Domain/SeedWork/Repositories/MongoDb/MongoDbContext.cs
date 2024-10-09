using MongoDB.Driver;
using Open.Shared.Libraries.ExtensionMethods;

namespace Open.Domain.SeedWork.Repositories.MongoDb;

public sealed class MongoDbContext
{
    private readonly IMongoDatabase _database;
    private readonly IMongoClient _client;
    
    public IMongoClient OriginClient => _client;

    public MongoDbContext(string connectionString, string databaseName)
    {
        _client = new MongoClient(connectionString);
        _database = _client.GetDatabase(databaseName);
    }
    
    public IMongoCollection<TDocument> GetCollection<TDocument>()
    {
        string collectionName = typeof(TDocument).Name.ToSnakeCaseLower();
        return _database.GetCollection<TDocument>(collectionName);
    }
}
