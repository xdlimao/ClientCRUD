// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29

using System.Collections.Generic;

namespace Ajinsoft.Tools.v3.Customers
{
public class CustomerSupport
{
public IEnumerable<CodeNameColor> Status => CustomerStatus.GetAll();
public IEnumerable<CodeName> Types => CustomerType.GetAll();
}
}
