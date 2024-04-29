// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29

using Ajinsoft.Commons.Extensions;
using Ajinsoft.Credentials3;
using Ajinsoft.Results;
using System.Threading.Tasks;

namespace Ajinsoft.Tools.v3.Customers
{
public static class CustomerUpdate
{
public static async Task<Customer> UpdateAsync(
this Customer @this,
CustomerParams @params,
Credential credential,
ICustomerRepository customerRepository, 
IAccountRepository accountRepository,
IPartnerRepository partnerRepository,
IStoreRepository storeRepository,
IBrokerRepository brokerRepository,
IResultService resultService)
{
await @this.SetParamsAsync(
@params,
credential,
customerRepository, 
accountRepository,
partnerRepository,
storeRepository,
brokerRepository,
resultService);

@this.RecordUpdate(credential);
@this.UpdateSearchText();

return @this;
}
}
}
