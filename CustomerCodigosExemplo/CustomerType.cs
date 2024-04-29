// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29

using System.Collections.Generic;
using Ajinsoft.Commons.Types;

namespace Ajinsoft.Tools.v3.Hierarchies
{
public class CustomerType : CodeName
{
public static CodeName Type1 = new(1, Words.Default);
public static CodeName Type2 = new(2, Words.Default);

public CustomerType(int code, string name) : base(code, name) { }
public static IEnumerable<CodeName> GetAll() => ReflectionFunctions.ListStaticFields(typeof(CustomerType)).Cast<CodeName>().ToList();
public static CodeName Get(int code) => Get(GetAll(), code);
}
}
