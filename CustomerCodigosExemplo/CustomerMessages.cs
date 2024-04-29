// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29


using Ajinsoft.Results;

namespace Ajinsoft.Tools.Customers
{
public class CustomerMessages
{
public static ResultMessage NotFound = new(ResultMessageTypes.Error, "Cliente não encontrado", "1006001");
}
}
