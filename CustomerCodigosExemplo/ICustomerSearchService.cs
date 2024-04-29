// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29


using System.Collections.Generic;
using System.Threading.Tasks;
using Ajinsoft.Commons.Entities;
using Ajinsoft.Results;
using Ajinsoft.Searches;
using Ajinsoft.Tools.v2.Shared.Entities.Aggregations;

namespace Ajinsoft.Tools.v3.Histories
{
public interface ICustomerSearchService
{
Task<SearchResult<CustomerSearchResult>> FindAsync(CustomerFilter filter);
Task<SearchResult<BasicResult>> FindBasicAsync(CustomerFilter filter);
Task<IList<CustomerSearchResult>> ListAsync(CustomerFilter filter);
Task<IList<IdCodeName>> ListSimpleAsync(CustomerFilter filter);
Task<Aggregation> AggregateByStatusAsync(CustomerFilter filter);
}
}
