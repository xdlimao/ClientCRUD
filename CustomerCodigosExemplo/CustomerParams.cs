// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29


namespace Ajinsoft
{
public class CustomerParams
{
public int? Code { get; set; }
public CodeNameParams? Feature { get; set; }
public CodeNameParams? Type { get; set; }
public string Name { get; set; }
public string Nickname { get; set; }
public string Description { get; set; }
public CodeNameParams? PersonType { get; set; }
public CodeNameParams? IdentityType { get; set; }
public string Identity { get; set; }
public string? BirthDate { get; set; }
public StatusFieldParams? Status { get; set; }
public bool? Enabled { get; set; }
public IList<AddressParams>? Addresses { get; set; }
public IList<PhoneParams>? Phones { get; set; }
public IList<EmailParams>? Emails { get; set; }
public IList<PersonDocumentParams>? Documents { get; set; }
public IList<BankAccountParams>? BankAccounts { get; set; }
public IList<DataFieldParams>? Fields { get; set; }
public IList<StatusFieldParams>? Tags { get; set; }
public IList<intParams>? TagCodes { get; set; }
public IList<StatusFieldParams>? Alerts { get; set; }
public IList<RelationshipFieldParams>? Relationships { get; set; }
public IdCodeNameParams? Parent { get; set; }
public StringIdNameParams? TimeZone { get; set; }
public string Avatar { get; set; }
public string Image { get; set; }
public string Color { get; set; }
public string ReferenceCode { get; set; }
public string ExternalCode { get; set; }
public IList<string>? Ids { get; set; }
public string Note { get; set; }
public string? DealerId { get; set; }
public string? AccountId { get; set; }
public string? PartnerId { get; set; }
public string? StoreId { get; set; }
public string? BrokerId { get; set; }
}
}
