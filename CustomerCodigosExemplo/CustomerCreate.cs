// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29

using System.Threading.Tasks;
using Ajinsoft.Commons.Extensions;
using Ajinsoft.Credentials3;
using Ajinsoft.Results;
using Ajinsoft.Tools.v2.Settings;

namespace Ajinsoft.Tools.v3.Customers
{
public partial class Customer
{
public static async Task<Customer> CreateAsync(
CustomerParams @params,
Credential credential,
ICustomerRepository customerRepository,
IAccountRepository accountRepository,
IPartnerRepository partnerRepository,
IStoreRepository storeRepository,
IBrokerRepository brokerRepository,
ICodeGenerator3Service codeGeneratorService,
IResultService resultService)
{
var model = new Customer();
model.SetDealer(credential);
model.SetCompany(credential);
model.SetAccount(credential);
model.SetPartner(credential);
model.SetStore(credential);
model.SetBroker(credential);

model.Id = @params.Id;
model.Code = @params.Code;
model.Feature = @params.Feature;
model.Type = @params.Type;
model.Name = @params.Name;
model.Nickname = @params.Nickname;
model.Description = @params.Description;
model.PersonType = @params.PersonType;
model.IdentityType = @params.IdentityType;
model.Identity = @params.Identity;
model.BirthDate = @params.BirthDate;
model.Status = @params.Status;
model.Enabled = @params.Enabled;
model.Addresses = @params.Addresses;
model.Phones = @params.Phones;
model.Emails = @params.Emails;
model.Documents = @params.Documents;
model.BankAccounts = @params.BankAccounts;
model.Fields = @params.Fields;
model.Tags = @params.Tags;
model.TagCodes = @params.TagCodes;
model.Alerts = @params.Alerts;
model.Relationships = @params.Relationships;
model.Parent = @params.Parent;
model.TimeZone = @params.TimeZone;
model.Avatar = @params.Avatar;
model.Image = @params.Image;
model.Color = @params.Color;
model.ReferenceCode = @params.ReferenceCode;
model.ExternalCode = @params.ExternalCode;
model.Ids = @params.Ids;
model.Note = @params.Note;

await model.SetDealerAsync(
@params.DealerId,
accountRepository);

await model.SetAccountAsync(
@params.AccountId,
accountRepository);

await model.SetPartnerAsync(
@params.PartnerId,
partnerRepository);

await model.SetStoreAsync(
@params.StoreId,
storeRepository);

await model.SetBrokerAsync(
@params.BrokerId,
brokerRepository);
model.Log = @params.Log;
model.RecordStatus = @params.RecordStatus;

await model.SetParamsAsync(
@params,
credential,
customerRepository,
accountRepository,
partnerRepository,
storeRepository,
brokerRepository,
resultService);

model.Code = await codeGeneratorService.GetNextCodeByFeatureAsync(credential.Company, Features.Feature.Customer);
model.RecordCreate(credential);
model.UpdateSearchText();
return model;
}
}
}
