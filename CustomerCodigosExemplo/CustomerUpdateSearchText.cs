// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29

using Ajinsoft.Searches;

namespace Ajinsoft.Tools.Customers
{
public static class CustomerUpdateSearchText
{
public static string UpdateSearchText(this Customer @this)
{
try
{
@this.SearchText = SearchFunctions.GetSearchText(
@this.Name,
@this.Nickname,
@this.Identity,
@this.ReferenceCode 
);

return @this.SearchText;
}
catch
{
return null;
}
}

}
}
