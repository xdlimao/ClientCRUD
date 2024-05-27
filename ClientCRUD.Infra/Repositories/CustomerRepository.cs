using ClientCRUD.Domain.Entities;
using ClientCRUD.Domain.Repositories;
using ClientCRUD.Infra.Context;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;


namespace ClientCRUD.Infra.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private MongoDbContext<Customer> _db;
    public CustomerRepository(MongoDbContext<Customer> mongoDbContext)
    {
        _db = mongoDbContext;
    }
    //Lembrando que todos os métodos são Async (preguiça de renomear, pois sem ReSharp xd)
    public async Task Delete(string id) //Done
    {
        var collection = _db.GetCollection<Customer>("customers");
        var filter = Builders<Customer>.Filter.Eq("_id", id);
        await collection.DeleteOneAsync(filter);
    }

    public async Task<List<Customer>> GetAll() //Done
    {
        var collection = _db.GetCollection<Customer>("customers");
        var filter = new BsonDocument();
        var result = await collection.FindAsync(filter);
        return await result.ToListAsync();
    }
    public async Task<List<Customer>> GetAllWithLimitAndSkip(int limit, int skip)
    {
        var collection = _db.GetCollection<Customer>("customers");
        var filter = new BsonDocument();
        var options = new FindOptions<Customer>
        {
            Limit = limit,
            Skip = skip
        };
        var result = await collection.FindAsync(filter, options);
        return await result.ToListAsync();
    }

    public async Task<Customer> GetById(string id) //Done
    {
        var collection = _db.GetCollection<Customer>("customers");
        var filter = Builders<Customer>.Filter.Eq("_id", id);
        var result = await collection.FindAsync(filter);
        return await result.FirstOrDefaultAsync();
    }

    public async Task Insert(Customer customer) //Done
    {
        var collection = _db.GetCollection<Customer>("customers");
        await collection.InsertOneAsync(customer);
    }

    public async Task Update(Customer customer)
    {
        var collection = _db.GetCollection<Customer>("customers");
        var filter = Builders<Customer>.Filter.Eq("_id", customer.Id);
        var update = Builders<Customer>.Update
            .Set("Code", customer.Code)
            .Set("Type", customer.Type)
            .Set("Name", customer.Name)
            .Set("Nickname", customer.Name)
            .Set("Description", customer.Description)
            .Set("PersonType", customer.PersonType)
            .Set("IdentityType", customer.IdentityType)
            .Set("Identity", customer.Identity)
            .Set("Birthdate", customer.Birthdate)
            .Set("Enabled", customer.Enabled)
            .Set("Addresses", customer.Addresses)
            .Set("Phones", customer.Phones)
            .Set("Emails", customer.Emails)
            .Set("Avatar", customer.Avatar)
            .Set("Image", customer.Image)
            .Set("Color", customer.Color)
            .Set("ReferenceCode", customer.ReferenceCode)
            .Set("Note", customer.Note);
        await collection.UpdateOneAsync(filter, update);
    }
}
