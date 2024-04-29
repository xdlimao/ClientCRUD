// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29

using Ajinsoft.Commons.Types;
using Ajinsoft.Constants;
using Ajinsoft.Languages;
using System.Collections.Generic;

namespace Ajinsoft.Tools.v3.Customers
{
public class CustomerStatus : CodeNameColor
{
public static CodeNameColor Active = new(1, Words.Active, MaterialColor.GREEN_500);
public static CodeNameColor Disabled = new(2, Words.Disabled, MaterialColor.GREY_500);
public static CodeNameColor Canceled = new(3, Words.Canceled, MaterialColor.RED_500);

public CustomerStatus(int code, string name, string color) : base(code, name, color) { }
public static IEnumerable<CodeNameColor> GetAll() => ReflectionFunctions.ListStaticFields(typeof(CustomerStatus)).Cast<CodeNameColor>().ToList();
public static CodeNameColor Get(int code) => Get(GetAll(), code);
}
}
