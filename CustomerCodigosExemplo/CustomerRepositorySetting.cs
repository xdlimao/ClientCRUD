// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29

namespace Ajinsoft.Tools.Repositories.Customers
{
public class CustomerRepositorySetting
{
public static string CollectionName =>  "customer";

public static void SetMapping()
{
CustomerEntityMapping.SetMapping();
}
}
}
