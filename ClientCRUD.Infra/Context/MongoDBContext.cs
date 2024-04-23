using ClientCRUD.Infra.Mappings;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCRUD.Infra.Context
{
    public class MongoDbContext <T>
    {
        private readonly IMongoDatabase collection;

        public MongoDbContext() 
        {
            var client = new MongoClient("mongodb://localhost:27017");
            collection = client.GetDatabase("Client");
            
        }
        public IMongoCollection<T> GetCollection<T>(string collectiondefiner)
        {
            return collection.GetCollection<T>(collectiondefiner);
        }
    }
}
