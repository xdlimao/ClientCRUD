// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29


namespace Ajinsoft
{
public class CustomerResult
{
public Guid Id { get; set; }
public int Code { get; set; }
public CodeName Feature { get; set; }
public CodeName Type { get; set; }
public string Name { get; set; }
public string Nickname { get; set; }
public string Description { get; set; }
public CodeName PersonType { get; set; }
public CodeName IdentityType { get; set; }
public string Identity { get; set; }
public string BirthDate { get; set; }
public StatusField Status { get; set; }
public bool Enabled { get; set; }
public IList<Address> Addresses { get; set; }
public IList<Phone> Phones { get; set; }
public IList<Email> Emails { get; set; }
public IList<PersonDocument> Documents { get; set; }
public IList<BankAccount> BankAccounts { get; set; }
public IList<DataField> Fields { get; set; }
public IList<StatusField> Tags { get; set; }
public IList<int> TagCodes { get; set; }
public IList<StatusField> Alerts { get; set; }
public IList<RelationshipField> Relationships { get; set; }
public IdCodeName Parent { get; set; }
public StringIdName TimeZone { get; set; }
public string Avatar { get; set; }
public string Image { get; set; }
public string Color { get; set; }
public string ReferenceCode { get; set; }
public string ExternalCode { get; set; }
public IList<Guid> Ids { get; set; }
public string Note { get; set; }
public IdCodeName Dealer { get; set; }
public IdCodeName Company { get; set; }
public IdCodeName Account { get; set; }
public IdCodeName Partner { get; set; }
public IdCodeName Store { get; set; }
public IdCodeName Broker { get; set; }
public RecordLogResult Log { get; set; }

public CustomerResult(Customer model, Credential credential)
{
this.Id = model.Id;
this.Code = model.Code;
this.Feature = model.Feature;
this.Type = model.Type;
this.Name = model.Name;
this.Nickname = model.Nickname;
this.Description = model.Description;
this.PersonType = model.PersonType;
this.IdentityType = model.IdentityType;
this.Identity = model.Identity;
this.BirthDate = DateFunctions3.GetStringDateTime(model.BirthDate, credential.TimeZoneInfo);
this.Status = model.Status;
this.Enabled = model.Enabled;
this.Addresses = model.Addresses;
this.Phones = model.Phones;
this.Emails = model.Emails;
this.Documents = model.Documents;
this.BankAccounts = model.BankAccounts;
this.Fields = model.Fields;
this.Tags = model.Tags;
this.TagCodes = model.TagCodes;
this.Alerts = model.Alerts;
this.Relationships = model.Relationships;
this.Parent = model.Parent;
this.TimeZone = model.TimeZone;
this.Avatar = model.Avatar;
this.Image = model.Image;
this.Color = model.Color;
this.ReferenceCode = model.ReferenceCode;
this.ExternalCode = model.ExternalCode;
this.Ids = model.Ids;
this.Note = model.Note;
this.Dealer = model.Dealer;
this.Company = model.Company;
this.Account = model.Account;
this.Partner = model.Partner;
this.Store = model.Store;
this.Broker = model.Broker;
this.Log = new RecordLogResult(model.Log, credential.TimeZoneInfo);
}

public override string ToString()
{
return this.Name;
}
}
}
