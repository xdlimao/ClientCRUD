using ClientCRUD.Infra.Context;
using ClientCRUD.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<MongoDbContext>();
builder.Services.AddScoped<CustomerRepository>();

var app = builder.Build();
app.MapControllers();
app.Run();
