using ClientCRUD.Domain.Entities;
using ClientCRUD.Infra.Context;
using ClientCRUD.Infra.Mappings;
using ClientCRUD.Infra.Repositories;
using ClientCRUD.Infra.Services;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using ClientCRUD.Domain.Repositories;
using ClientCRUD.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

CustomerMapping.CustomerMappingSet(); //Chame essa classe antes de chamar o MongoDbContext, se não ira dar erro de mapeamento já feito.
ComplexTypesMapping.ComplexTypesMappingSet();

BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));

builder.Services.AddControllers();
builder.Services.AddScoped<MongoDbContext<Customer>>();
builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<CustomerServices>();


var app = builder.Build();
app.MapControllers();
app.Run();
