// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29

using System.Threading.Tasks;
using Ajinsoft.Credentials;

namespace Ajinsoft.Tools.Customers
{
public interface ICustomerLevelService
{
Task<CustomerLevelFilter> GetFilterAsync();
Task<bool> HasAccessAsync(Guid id);
}
}
