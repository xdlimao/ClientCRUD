using ClientCRUD.Domain.Entities;
using ClientCRUD.Infra.Context;
using ClientCRUD.Infra.Mappings;
using ClientCRUD.Infra.Repositories;
using ClientCRUD.Infra.Services;
using ClientCRUD.Infra;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

CustomerMapping.CustomerMappingSet(); //Chame essa classe antes de chamar o MongoDbContext, se não ira dar erro de mapeamento já feito.
UserMapping.UserMappingSet();
ComplexTypesMapping.ComplexTypesMappingSet();

BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));

builder.Services.AddTransient<TokenService>();

builder.Services.AddControllers();
builder.Services.AddScoped<MongoDbContext<Customer>>();
builder.Services.AddScoped<MongoDbContext<User>>();
builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<CustomerServices>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserServices>();

builder.Services.AddCors(
        x => x.AddPolicy("MyPolitic", 
        policy => policy
        .WithOrigins(["http://localhost:4200", "http://localhost:5011", "https://localhost:7036"])
        //.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        ));

builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters()
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.PrivateKey)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("MyPolitic");

app.MapGet("/oi", () => "admin").RequireAuthorization();

app.MapControllers();

app.Run();  
