using Ajinsoft.Tools.Customers;
using Ajinsoft.Tools.Repositories.Customers;
using Ajinsoft.Tools.Services.Customers;
using Microsoft.Extensions.DependencyInjection;

namespace Ajinsoft.Tools.Api.Injections.Tools
{
public static class CustomerDependency
{
public static void AddCustomerDependencies(this IServiceCollection services)
{
//Customers
CustomerRepositorySetting.SetMapping();
services.AddScoped<ICustomerRepository, CustomerRepository>();
services.AddScoped<ICustomerService, CustomerService>();
services.AddScoped<ICustomerSearchRepository, CustomerSearchRepository>();
services.AddScoped<ICustomerSearchService, CustomerSearchService>();
services.AddScoped<ICustomerLevelService, CustomerLevelService>();
}
}
}
