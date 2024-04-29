// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29


namespace Ajinsoft
{
public class CustomerFilter : BaseFilter
{
public GuidFilter Id { get; set; }
public IntFilter Code { get; set; }
public CodeNameFilter Feature { get; set; }
public CodeNameFilter Type { get; set; }
public StringFilter Name { get; set; }
public StringFilter Nickname { get; set; }
public StringFilter Description { get; set; }
public CodeNameFilter PersonType { get; set; }
public CodeNameFilter IdentityType { get; set; }
public StringFilter Identity { get; set; }
public DateTimeFilter BirthDate { get; set; }
public StatusFieldFilter Status { get; set; }
public BooleanFilter Enabled { get; set; }
public IntListFilter TagCodes { get; set; }
public IdCodeNameFilter Parent { get; set; }
public StringFilter Avatar { get; set; }
public StringFilter Image { get; set; }
public StringFilter Color { get; set; }
public StringFilter ReferenceCode { get; set; }
public StringFilter ExternalCode { get; set; }
public GuidListFilter Ids { get; set; }
public StringFilter Note { get; set; }
public IdCodeNameFilter Dealer { get; set; }
public IdCodeNameFilter Company { get; set; }
public IdCodeNameFilter Account { get; set; }
public IdCodeNameFilter Partner { get; set; }
public IdCodeNameFilter Store { get; set; }
public IdCodeNameFilter Broker { get; set; }
public RecordLogFilter Log { get; set; }
public List<FilterField> Filters { get; set; }
}
}
