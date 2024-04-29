// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29


namespace Ajinsoft;

public partial class Customer : 
	IRecordLogField, 
	ICompanyField,
	IAccountField,
	IStoreField,
	IBrokerField,
	IDealerField,
	IPartnerField,
	IIdsField
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
	public DateTime? BirthDate { get; set; }
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
	public RecordLog Log { get; set; }
	public short RecordStatus { get; set; }
	public string SearchText { get; set; }

	public Customer()
	{
		this.Id = Guid.NewGuid();
		this.Feature = new CodeName();
		this.Type = new CodeName();
		this.PersonType = new CodeName();
		this.IdentityType = new CodeName();
		this.Status = new StatusField();
		this.Addresses = new List<Address>();
		this.Phones = new List<Phone>();
		this.Emails = new List<Email>();
		this.Documents = new List<PersonDocument>();
		this.BankAccounts = new List<BankAccount>();
		this.Fields = new List<DataField>();
		this.Tags = new List<StatusField>();
		this.TagCodes = new List<int>();
		this.Alerts = new List<StatusField>();
		this.Relationships = new List<RelationshipField>();
		this.Parent = new IdCodeName();
		this.Ids = new List<Guid>();
		this.Dealer = new IdCodeName();
		this.Company = new IdCodeName();
		this.Account = new IdCodeName();
		this.Partner = new IdCodeName();
		this.Store = new IdCodeName();
		this.Broker = new IdCodeName();
		this.Log = new RecordLog();
	}

	public override string ToString()
	{
		return this.Name;
	}
}

