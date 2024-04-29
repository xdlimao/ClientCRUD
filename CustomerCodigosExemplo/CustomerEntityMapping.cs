// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29


using MongoDB.Bson.Serialization;

namespace Ajinsoft
{
public static class CustomerEntityMapping
{
public static void SetMapping()
{
BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

if (BsonClassMap.IsClassMapRegistered(typeof(Customer)))
return;

BsonClassMap.RegisterClassMap<Customer>(cm =>
{
cm.AutoMap();
cm.SetIgnoreExtraElements(true);
cm.MapIdProperty(c => c.Id);
cm.MapMember(c => c.Code).SetElementName("code");
cm.MapMember(c => c.Feature).SetElementName("feature");
cm.MapMember(c => c.Type).SetElementName("type");
cm.MapMember(c => c.Name).SetElementName("name");
cm.MapMember(c => c.Nickname).SetElementName("nickname");
cm.MapMember(c => c.Description).SetElementName("description");
cm.MapMember(c => c.PersonType).SetElementName("person_type");
cm.MapMember(c => c.IdentityType).SetElementName("identity_type");
cm.MapMember(c => c.Identity).SetElementName("identity");
cm.MapMember(c => c.BirthDate).SetElementName("birth_date");
cm.MapMember(c => c.Status).SetElementName("status");
cm.MapMember(c => c.Enabled).SetElementName("enabled");
cm.MapMember(c => c.Addresses).SetElementName("addresses");
cm.MapMember(c => c.Phones).SetElementName("phones");
cm.MapMember(c => c.Emails).SetElementName("emails");
cm.MapMember(c => c.Documents).SetElementName("documents");
cm.MapMember(c => c.BankAccounts).SetElementName("bank_accounts");
cm.MapMember(c => c.Fields).SetElementName("fields");
cm.MapMember(c => c.Tags).SetElementName("tags");
cm.MapMember(c => c.TagCodes).SetElementName("tag_codes");
cm.MapMember(c => c.Alerts).SetElementName("alerts");
cm.MapMember(c => c.Relationships).SetElementName("relationships");
cm.MapMember(c => c.Parent).SetElementName("parent");
cm.MapMember(c => c.TimeZone).SetElementName("time_zone");
cm.MapMember(c => c.Avatar).SetElementName("avatar");
cm.MapMember(c => c.Image).SetElementName("image");
cm.MapMember(c => c.Color).SetElementName("color");
cm.MapMember(c => c.ReferenceCode).SetElementName("reference_code");
cm.MapMember(c => c.ExternalCode).SetElementName("external_code");
cm.MapMember(c => c.Ids).SetElementName("ids");
cm.MapMember(c => c.Note).SetElementName("note");
cm.MapMember(c => c.Dealer).SetElementName("dealer");
cm.MapMember(c => c.Company).SetElementName("company");
cm.MapMember(c => c.Account).SetElementName("account");
cm.MapMember(c => c.Partner).SetElementName("partner");
cm.MapMember(c => c.Store).SetElementName("store");
cm.MapMember(c => c.Broker).SetElementName("broker");
cm.MapMember(c => c.Log).SetElementName("log");
cm.MapMember(c => c.RecordStatus).SetElementName("record_status");
cm.MapMember(c => c.SearchText).SetElementName("search_text");
});
}
}
}
