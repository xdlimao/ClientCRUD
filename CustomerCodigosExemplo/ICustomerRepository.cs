// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29


using Ajinsoft.Registers.Records;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ajinsoft.Tools.Customers
{
public interface ICustomerRepository
{
Task<Customer> InsertAsync(Customer customer);
Task InsertManyAsync(IList<Customer> customers);
Task<long> UpdateAsync(Customer customer);
Task<long> DeleteAsync(Guid id);
Task<Customer> GetAsync(Guid id);
Task<Customer> GetAsync(Credential credential, Guid id);
Task<Customer> GetAnyAsync(Guid id);
Task<Customer> GetAsync(Credential credential, int code);
Task<IdCodeName> GetIdCodeNameAsync(Credential credential, Guid id);
Task<IdCodeName> GetAnyIdCodeNameAsync(Guid id);
Task<IList<Customer>> FindByAccountAsync(Guid accountId, int offset = 0, int limit = 0, bool any = false);
Task<IList<Customer>> FindByCompanyAsync(Guid companyId, int offset = 0, int limit = 0, bool any = false);
Task<IList<Customer>> FindAllAsync(int offset = 0, int limit = 0);
Task<IList<Guid>> ListIdsAsync(Credential credential, CustomerLevelFilter level, CustomerFilter filter);
Task<bool> ExistsAsync(Guid id, CustomerLevelFilter level);
}
}
