using ClientCRUD.Domain.Entities;
using ClientCRUD.Infra.Context;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCRUD.Infra.Services
{
    public class CodeGenerator //Ver se funfa
    {
        private readonly MongoDbContext<Customer> _db;
        public CodeGenerator(MongoDbContext<Customer> mongoDbContext)
        {
            _db = mongoDbContext;
        }
        public int GenerateCode(string collectionname)
        {
            var collection = _db.GetCollection<Customer>(collectionname);
            var filter = Builders<Customer>.Filter.Empty;
            var documents = collection.Find(filter).ToList();
            if (documents.Count == 0) return 1;
            return documents.Count + 1;
        }
    }
}
