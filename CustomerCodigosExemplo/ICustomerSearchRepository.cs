// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29


using Ajinsoft.Searches;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ajinsoft.Tools.v3.Histories
{
public interface ICustomerSearchRepository
{
Task<SearchResult<CustomerSearchResult>> FindAsync(Credential credential, CustomerLevelFilter level, CustomerFilter filter, DataLevel dataLevel = DataLevel.Company);
Task<SearchResult<BasicResult>> FindBasicAsync(Credential credential, CustomerLevelFilter level, CustomerFilter filter, DataLevel dataLevel = DataLevel.Company);
Task<IList<CustomerSearchResult>> ListAsync(Credential credential, CustomerLevelFilter level, CustomerFilter filter, DataLevel dataLevel = DataLevel.Company);
Task<IList<IdCodeName>> ListSimpleAsync(Credential credential, CustomerLevelFilter level, CustomerFilter filter, DataLevel dataLevel = DataLevel.Company);
Task<long> CountAsync(Credential credential, CustomerLevelFilter level, CustomerFilter filter, DataLevel dataLevel = DataLevel.Company);
Task<IList<AggregationItem>> AggregateByStatusAsync(Credential credential, CustomerLevelFilter level, CustomerFilter filter, DataLevel dataLevel = DataLevel.Company);
}
}
