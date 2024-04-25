using ClientCRUD.Domain.Entities;
using ClientCRUD.Domain.Repositories;
using ClientCRUD.Infra.Context;
using ClientCRUD.Shared.ComplexTypes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClientCRUD.Infra.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private MongoDbContext<Customer> _db;
    public CustomerRepository(MongoDbContext<Customer> mongoDbContext)
    {
        _db = mongoDbContext;
    }
    public void Delete(string id) //Done
    {
        var collection = _db.GetCollection<Customer>("customers");
        var filter = Builders<Customer>.Filter.Eq("_id", id);
        collection.DeleteOne(filter);
    }

    public List<Customer> GetAll() //Done
    {
        var collection = _db.GetCollection<Customer>("customers");
        var filter = new BsonDocument();
        return collection.Find(filter).ToList();       
    }

    public Customer GetById(string id) //Done
    {
        var collection = _db.GetCollection<Customer>("customers");
        var filter = Builders<Customer>.Filter.Eq("_id", id);
        return collection.Find(filter).FirstOrDefault();
    }

    public void Insert(Customer customer) //Done
    {
        var collection = _db.GetCollection<Customer>("customers");
        collection.InsertOne(customer);
    }

    public void Update(Customer customer)
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
        collection.UpdateOne(filter, update);
    }
}
