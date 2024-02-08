using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TodoApi.Models;

namespace TodoApi.Shared;

public class AbstractMongoDB<T>
{
    protected readonly IMongoCollection<T> _collection;
    
    public AbstractMongoDB(MongoClientOptions options, IMongoClient client, string collectionName)
    {
        var mongoDatabase = client.GetDatabase(options.Database);

        _collection = mongoDatabase.GetCollection<T>(collectionName);
    }
}
