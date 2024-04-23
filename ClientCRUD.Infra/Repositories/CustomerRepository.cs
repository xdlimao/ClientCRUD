using ClientCRUD.Domain.Entities;
using ClientCRUD.Domain.Repositories;
using ClientCRUD.Infra.Context;
using ClientCRUD.Infra.Services;
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

public class CustomerRepository : ICustomerRepository
{
    private MongoDbContext<Customer> _db;
    private CodeGenerator _cg;
    public CustomerRepository(MongoDbContext<Customer> mongoDbContext, CodeGenerator codeGenerator)
    {
        _db = mongoDbContext;
        _cg = codeGenerator;
    }
    //public void Delete(string id) //Done
    //{
    //    var collection = _db.GetCollection<Customer>("customers");
    //    var filter = Builders<Customer>.Filter.Eq("_id", id);
    //    collection.DeleteOne(filter);
    //}

    public List<Customer> GetAll() //Done
    {
        var collection = _db.GetCollection<Customer>("customers");
        var filter = new BsonDocument();
        var document = collection.Find(filter).ToList();
        List<Customer> customers = document;

        return customers;
    }

    //public Customer GetByCode(string id) //Done
    //{
    //    var collection = _db.GetCollection<Customer>("customers");
    //    var filter = Builders<Customer>.Filter.Eq("_id", id);
    //    var document = collection.Find(filter).FirstOrDefault();
    //    if (document == null)
    //        return null;
    //    Customer customer = BsonSerializer.Deserialize<Customer>(document);
    //    return customer;
    //}

    //public void Insert(string namer)
    //{
    //    var collection = _db.GetCollection("customers");
    //    Customer document = new()
    //    {
    //        Id = Guid.NewGuid(),
    //        code = _cg.GenerateCode("customers"),
    //        type = new CodeName()
    //        {
    //            code = , 
    //            name =
    //        },
    //        name = ,
    //        nickname = ,
    //        description = ,
    //        person_type = new CodeName()
    //        {
    //            code = ,
    //            name = ,
    //        },
    //        identity_type= new CodeName()
    //        {
    //            code = ,
    //            name = ,
    //        },
    //        identity = ,
    //        brithdate = ,
    //        enabled = true,
    //        addresses = /*cria var com lista e add aqui*/,
    //        phones = /*cria var com lista e add aqui*/,
    //        emails = /*cria var com lista e add aqui*/,
    //        avatar = ,
    //        image = ,
    //        color = ,
    //        reference_code = ,
    //        note =

    //    };
    //    //collection.InsertOne(newDoc);
    //}

    //public void Update(string oldName, string newName)
    //{
    //    var collection = _db.GetCollection("customers");
    //    var filter = Builders<BsonDocument>.Filter.Eq("name", oldName);
    //    var update = Builders<BsonDocument>.Update.Set("name", newName);
    //    collection.UpdateOne(filter, update);
    //}
}

