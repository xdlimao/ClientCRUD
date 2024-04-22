using MongoDB.Driver;

namespace ClientCRUD.Infra.Context;
public class MongoDBContext
{
    private const string _connectionString = "";
    private readonly IMongoDatabase _database;

    public MongoDBContext(string databaseName)
    {
        var client = new MongoClient(_connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<T> GetCollection<T>(string collectionName)
    {
        return _database.GetCollection<T>(collectionName);
    }
}