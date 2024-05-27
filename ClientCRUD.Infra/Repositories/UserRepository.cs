using ClientCRUD.Domain.Entities;
using ClientCRUD.Domain.Repositories;
using ClientCRUD.Infra.Context;
using DnsClient;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCRUD.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private MongoDbContext<User> _db;
        public UserRepository(MongoDbContext<User> mongoDbContext)
        {
            _db = mongoDbContext;
        }

        public async Task<User> GetById(Guid id)
        {
            var collection = _db.GetCollection<User>("users");
            var filter = Builders<User>.Filter.Eq("_id", id);
            var result = await collection.FindAsync(filter);
            return await result.FirstOrDefaultAsync();
        }

        public async Task<User> GetByLogin(string login)
        {
            var collection = _db.GetCollection<User>("users");
            var filter = Builders<User>.Filter.Eq("login", login);
            var result = await collection.FindAsync(filter);
            return await result.FirstOrDefaultAsync();
        }
    }
}
