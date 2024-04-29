// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29


namespace Ajinsoft
{
public static class CustomerSetParams
{
public static async Task<Customer> SetParamsAsync(
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
if (@params.Feature is not null)
@this.Feature = CodeName.Create(@params.Feature);

if (@params.Type is not null)
@this.Type = CodeName.Create(@params.Type);

if (@params.Name is not null)
@this.Name = @params.Name;

if (@params.Nickname is not null)
@this.Nickname = @params.Nickname;

if (@params.Description is not null)
@this.Description = @params.Description;

if (@params.PersonType is not null)
@this.PersonType = CodeName.Create(@params.PersonType);

if (@params.IdentityType is not null)
@this.IdentityType = CodeName.Create(@params.IdentityType);

if (@params.Identity is not null)
@this.Identity = @params.Identity;

if (@params.BirthDate is not null)
@this.BirthDate = DateFunctions3.ToDateTime(@params.BirthDate);

if (@params.Status is not null)
@this.Status = StatusField.Create(@params.Status);

if (@params.Enabled is not null)
@this.Enabled = (bool)@params.Enabled;

if (@params.Addresses is not null)
@this.Addresses = Address.CreateList(@params.Addresses);

if (@params.Phones is not null)
@this.Phones = Phone.CreateList(@params.Phones);

if (@params.Emails is not null)
@this.Emails = Email.CreateList(@params.Emails);

if (@params.Documents is not null)
@this.Documents = PersonDocument.CreateList(@params.Documents);

if (@params.BankAccounts is not null)
@this.BankAccounts = BankAccount.CreateList(@params.BankAccounts);

if (@params.Fields is not null)
@this.Fields = DataField.CreateList(@params.Fields);

if (@params.Tags is not null)
@this.Tags = StatusField.CreateList(@params.Tags);

if (@params.TagCodes is not null)
@this.TagCodes = int.CreateList(@params.TagCodes);

if (@params.Alerts is not null)
@this.Alerts = StatusField.CreateList(@params.Alerts);

if (@params.Relationships is not null)
@this.Relationships = RelationshipField.CreateList(@params.Relationships);

if (@params.Parent is not null)
@this.Parent = IdCodeName.Create(@params.Parent);

if (@params.TimeZone is not null)
@this.TimeZone = StringIdName.Create(@params.TimeZone);

if (@params.Avatar is not null)
@this.Avatar = @params.Avatar;

if (@params.Image is not null)
@this.Image = @params.Image;

if (@params.Color is not null)
@this.Color = @params.Color;

if (@params.ReferenceCode is not null)
@this.ReferenceCode = @params.ReferenceCode;

if (@params.ExternalCode is not null)
@this.ExternalCode = @params.ExternalCode;

if (@params.Ids is not null)
@this.Ids = Guid.CreateList(@params.Ids);

if (@params.Note is not null)
@this.Note = @params.Note;

await @this.SetDealerAsync(
@params.DealerId,
accountRepository);

await @this.SetAccountAsync(
@params.AccountId,
accountRepository);

await @this.SetPartnerAsync(
@params.PartnerId,
partnerRepository);

await @this.SetStoreAsync(
@params.StoreId,
storeRepository);

await @this.SetBrokerAsync(
@params.BrokerId,
brokerRepository);


@this.AddIds(
@this.Dealer,
@this.Company,
@this.Account,
@this.Partner,
@this.Store,
@this.Broker);

@this.UpdateSearchText();

return @this;
}
}
}
