// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29


using Ajinsoft.ResultMessages;
using Ajinsoft.Registers.Results;
using Ajinsoft.Tools.Customers.Supports;
using Ajinsoft.Tools.Shared.Params;
using System;
using System.Threading.Tasks;
using Ajinsoft.Tools.Exports;

namespace Ajinsoft.Tools.Customers
{
public interface ICustomerService
{
Task<CustomerResult> CreateAsync(CustomerParams @params);
Task<CustomerResult> UpdateAsync(Guid id, CustomerParams @params);
Task<CustomerResult> UpdateStatusAsync(Guid id, UpdateStatusParams @params);
Task<CountResult> DeleteAsync(IdListParams @params);
Task<CountResult> RestoreAsync(IdListParams @params);
Task<CustomerResult> GetAsync(Guid id);
Task<CustomerSupport> GetSupportAsync();
Task<IEnumerable<FilterFieldType>> GetFilterFieldsAsync();
}
}
