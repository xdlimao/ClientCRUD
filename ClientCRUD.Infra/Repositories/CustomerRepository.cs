using ClientCRUD.Domain.Entities;
using ClientCRUD.Infra.Context;
using ClientCRUD.Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClientCRUD.Infra.Repositories;
public class Customer
{
    public ObjectId Id { get; set; }
    public string? name { get; set; }
}

public class CustomerRepository : ICustomerRepository
{
    public MongoDbContext _db;
    public CustomerRepository(MongoDbContext mongoDbContext)
    {
        _db = mongoDbContext;
    }
    public void Delete(string name)
    {
        var collection = _db.GetCollection("customers");
        var filter = Builders<BsonDocument>.Filter.Eq("name", name);
        collection.DeleteOne(filter);
    }

    public List<Customer> GetAll()
    {
        var collection = _db.GetCollection("customers");
        var filter = new BsonDocument();
        var document = collection.Find(filter).ToList();
        List<Customer> customers = document.Select(doc => BsonSerializer.Deserialize<Customer>(doc)).ToList();

        return customers;
    }

    public Customer GetByCode(string name)
    {
        var collection = _db.GetCollection("customers");
        var filter = Builders<BsonDocument>.Filter.Eq("name", name);
        var document = collection.Find(filter).FirstOrDefault();
        Customer customer = BsonSerializer.Deserialize<Customer>(document);

        return customer;
    }

    public void Insert(string namer)
    {
        var collection = _db.GetCollection("customers");
        Customer document = new() { Id = ObjectId.GenerateNewId(), name = namer };
        BsonDocument newDoc = new() { { "_id" , document.Id }, { "name", document.name } };
        collection.InsertOne(newDoc);
    }

    public Customer Update()
    {
        throw new NotImplementedException();
    }
}

