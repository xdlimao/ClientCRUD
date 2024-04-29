// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29


namespace Ajinsoft
{
public class CustomerSearchResult
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
public IdCodeName Parent { get; set; }
public StringIdName TimeZone { get; set; }
public string Avatar { get; set; }
public string Image { get; set; }
public string Color { get; set; }
public string ReferenceCode { get; set; }
public string ExternalCode { get; set; }
public string Note { get; set; }
public IdCodeName Dealer { get; set; }
public IdCodeName Company { get; set; }
public IdCodeName Account { get; set; }
public IdCodeName Partner { get; set; }
public IdCodeName Store { get; set; }
public IdCodeName Broker { get; set; }
public RecordLogResult Log { get; set; }

}
}
