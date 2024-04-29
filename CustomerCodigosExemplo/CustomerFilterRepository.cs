// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29


namespace Ajinsoft
{
public class CustomerFilterRepository
{

public CustomerFilterRepository()
{
}

public FilterDefinition<Customer> GetFilter(Credential credential, CustomerFilter filter)
{
this.SetFilters(filter);

var fb = Builders<Customer>.Filter;

var fd = fb.Where(_ => true);

if (filter is null)
return fd;

var fu = new FilterUtil();

var texts = fu.ParseSearchText(filter.SearchText);
foreach (var text in texts)
fd &= fb.Regex(x => x.SearchText, new Regex(text, RegexOptions.IgnoreCase));


if (filter.Id is not null)
{
if (fu.Assert(filter.Id.Eq?.ToNullableGuid())) fd &= fb.Eq(x => x.Id, filter.Id.Eq.ToGuid());
if (fu.Assert(filter.Id.Ne?.ToNullableGuid())) fd &= fb.Ne(x => x.Id, filter.Id.Ne.ToGuid());
if (fu.Assert(filter.Id.In?.ToListGuid())) fd &= fb.In(x => x.Id, filter.Id.In?.ToListGuid());
if (fu.Assert(filter.Id.Nin?.ToListGuid())) fd &= fb.Nin(x => x.Id, filter.Id.Nin?.ToListGuid());
}

if (filter.Code is not null)
{
if (fu.Assert(filter.Code.Eq)) fd &= fb.Eq(x => x.Code, filter.Code.Eq);
if (fu.Assert(filter.Code.Ne)) fd &= fb.Ne(x => x.Code, filter.Code.Ne);
if (fu.Assert(filter.Code.In)) fd &= fb.In(x => x.Code, filter.Code.In);
if (fu.Assert(filter.Code.Nin)) fd &= fb.Nin(x => x.Code, filter.Code.Nin);
if (fu.Assert(filter.Code.Gt)) fd &= fb.Gt(x => x.Code, filter.Code.Gt);
if (fu.Assert(filter.Code.Gte)) fd &= fb.Gte(x => x.Code, filter.Code.Gte);
if (fu.Assert(filter.Code.Lt)) fd &= fb.Lt(x => x.Code, filter.Code.Lt);
if (fu.Assert(filter.Code.Lte)) fd &= fb.Lte(x => x.Code, filter.Code.Lte);
}

if (filter.Feature is not null)
{
if (filter.Feature.Code is not null)
{
if (fu.Assert(filter.Feature.Code.Eq)) fd &= fb.Eq(x => x.Feature.Code, filter.Feature.Code.Eq);
if (fu.Assert(filter.Feature.Code.Ne)) fd &= fb.Ne(x => x.Feature.Code, filter.Feature.Code.Ne);
if (fu.Assert(filter.Feature.Code.In)) fd &= fb.In(x => x.Feature.Code, filter.Feature.Code.In);
if (fu.Assert(filter.Feature.Code.Nin)) fd &= fb.Nin(x => x.Feature.Code, filter.Feature.Code.Nin);
if (fu.Assert(filter.Feature.Code.Gt)) fd &= fb.Gt(x => x.Feature.Code, filter.Feature.Code.Gt);
if (fu.Assert(filter.Feature.Code.Gte)) fd &= fb.Gte(x => x.Feature.Code, filter.Feature.Code.Gte);
if (fu.Assert(filter.Feature.Code.Lt)) fd &= fb.Lt(x => x.Feature.Code, filter.Feature.Code.Lt);
if (fu.Assert(filter.Feature.Code.Lte)) fd &= fb.Lte(x => x.Feature.Code, filter.Feature.Code.Lte);
}

if (filter.Feature.Name is not null)
{
if (fu.Assert(filter.Feature.Name.Eq)) fd &= fb.Eq(x => x.Feature.Name, filter.Feature.Name.Eq);
if (fu.Assert(filter.Feature.Name.Ne)) fd &= fb.Ne(x => x.Feature.Name, filter.Feature.Name.Ne);
if (fu.Assert(filter.Feature.Name.St)) fd &= fb.Regex(x => x.Feature.Name, RegexFunctions.St(filter.Feature.Name.St));
if (fu.Assert(filter.Feature.Name.Ed)) fd &= fb.Regex(x => x.Feature.Name, RegexFunctions.Ed(filter.Feature.Name.Ed));
if (fu.Assert(filter.Feature.Name.Nst)) fd &= fb.Regex(x => x.Feature.Name, RegexFunctions.Nst(filter.Feature.Name.Nst));
if (fu.Assert(filter.Feature.Name.Ned)) fd &= fb.Regex(x => x.Feature.Name, RegexFunctions.Ned(filter.Feature.Name.Ned));
if (fu.Assert(filter.Feature.Name.Regex)) fd &= fb.Regex(x => x.Feature.Name, RegexFunctions.Regex(filter.Feature.Name.Regex));
}
}

if (filter.Type is not null)
{
if (filter.Type.Code is not null)
{
if (fu.Assert(filter.Type.Code.Eq)) fd &= fb.Eq(x => x.Type.Code, filter.Type.Code.Eq);
if (fu.Assert(filter.Type.Code.Ne)) fd &= fb.Ne(x => x.Type.Code, filter.Type.Code.Ne);
if (fu.Assert(filter.Type.Code.In)) fd &= fb.In(x => x.Type.Code, filter.Type.Code.In);
if (fu.Assert(filter.Type.Code.Nin)) fd &= fb.Nin(x => x.Type.Code, filter.Type.Code.Nin);
if (fu.Assert(filter.Type.Code.Gt)) fd &= fb.Gt(x => x.Type.Code, filter.Type.Code.Gt);
if (fu.Assert(filter.Type.Code.Gte)) fd &= fb.Gte(x => x.Type.Code, filter.Type.Code.Gte);
if (fu.Assert(filter.Type.Code.Lt)) fd &= fb.Lt(x => x.Type.Code, filter.Type.Code.Lt);
if (fu.Assert(filter.Type.Code.Lte)) fd &= fb.Lte(x => x.Type.Code, filter.Type.Code.Lte);
}

if (filter.Type.Name is not null)
{
if (fu.Assert(filter.Type.Name.Eq)) fd &= fb.Eq(x => x.Type.Name, filter.Type.Name.Eq);
if (fu.Assert(filter.Type.Name.Ne)) fd &= fb.Ne(x => x.Type.Name, filter.Type.Name.Ne);
if (fu.Assert(filter.Type.Name.St)) fd &= fb.Regex(x => x.Type.Name, RegexFunctions.St(filter.Type.Name.St));
if (fu.Assert(filter.Type.Name.Ed)) fd &= fb.Regex(x => x.Type.Name, RegexFunctions.Ed(filter.Type.Name.Ed));
if (fu.Assert(filter.Type.Name.Nst)) fd &= fb.Regex(x => x.Type.Name, RegexFunctions.Nst(filter.Type.Name.Nst));
if (fu.Assert(filter.Type.Name.Ned)) fd &= fb.Regex(x => x.Type.Name, RegexFunctions.Ned(filter.Type.Name.Ned));
if (fu.Assert(filter.Type.Name.Regex)) fd &= fb.Regex(x => x.Type.Name, RegexFunctions.Regex(filter.Type.Name.Regex));
}
}

if (filter.Name is not null)
{
if (fu.Assert(filter.Name.Eq)) fd &= fb.Eq(x => x.Name, filter.Name.Eq);
if (fu.Assert(filter.Name.Ne)) fd &= fb.Ne(x => x.Name, filter.Name.Ne);
if (fu.Assert(filter.Name.St)) fd &= fb.Regex(x => x.Name, RegexFunctions.St(filter.Name.St));
if (fu.Assert(filter.Name.Ed)) fd &= fb.Regex(x => x.Name, RegexFunctions.Ed(filter.Name.Ed));
if (fu.Assert(filter.Name.Nst)) fd &= fb.Regex(x => x.Name, RegexFunctions.Nst(filter.Name.Nst));
if (fu.Assert(filter.Name.Ned)) fd &= fb.Regex(x => x.Name, RegexFunctions.Ned(filter.Name.Ned));
if (fu.Assert(filter.Name.Regex)) fd &= fb.Regex(x => x.Name, RegexFunctions.Regex(filter.Name.Regex));
}

if (filter.Nickname is not null)
{
if (fu.Assert(filter.Nickname.Eq)) fd &= fb.Eq(x => x.Nickname, filter.Nickname.Eq);
if (fu.Assert(filter.Nickname.Ne)) fd &= fb.Ne(x => x.Nickname, filter.Nickname.Ne);
if (fu.Assert(filter.Nickname.St)) fd &= fb.Regex(x => x.Nickname, RegexFunctions.St(filter.Nickname.St));
if (fu.Assert(filter.Nickname.Ed)) fd &= fb.Regex(x => x.Nickname, RegexFunctions.Ed(filter.Nickname.Ed));
if (fu.Assert(filter.Nickname.Nst)) fd &= fb.Regex(x => x.Nickname, RegexFunctions.Nst(filter.Nickname.Nst));
if (fu.Assert(filter.Nickname.Ned)) fd &= fb.Regex(x => x.Nickname, RegexFunctions.Ned(filter.Nickname.Ned));
if (fu.Assert(filter.Nickname.Regex)) fd &= fb.Regex(x => x.Nickname, RegexFunctions.Regex(filter.Nickname.Regex));
}

if (filter.Description is not null)
{
if (fu.Assert(filter.Description.Eq)) fd &= fb.Eq(x => x.Description, filter.Description.Eq);
if (fu.Assert(filter.Description.Ne)) fd &= fb.Ne(x => x.Description, filter.Description.Ne);
if (fu.Assert(filter.Description.St)) fd &= fb.Regex(x => x.Description, RegexFunctions.St(filter.Description.St));
if (fu.Assert(filter.Description.Ed)) fd &= fb.Regex(x => x.Description, RegexFunctions.Ed(filter.Description.Ed));
if (fu.Assert(filter.Description.Nst)) fd &= fb.Regex(x => x.Description, RegexFunctions.Nst(filter.Description.Nst));
if (fu.Assert(filter.Description.Ned)) fd &= fb.Regex(x => x.Description, RegexFunctions.Ned(filter.Description.Ned));
if (fu.Assert(filter.Description.Regex)) fd &= fb.Regex(x => x.Description, RegexFunctions.Regex(filter.Description.Regex));
}

if (filter.PersonType is not null)
{
if (filter.PersonType.Code is not null)
{
if (fu.Assert(filter.PersonType.Code.Eq)) fd &= fb.Eq(x => x.PersonType.Code, filter.PersonType.Code.Eq);
if (fu.Assert(filter.PersonType.Code.Ne)) fd &= fb.Ne(x => x.PersonType.Code, filter.PersonType.Code.Ne);
if (fu.Assert(filter.PersonType.Code.In)) fd &= fb.In(x => x.PersonType.Code, filter.PersonType.Code.In);
if (fu.Assert(filter.PersonType.Code.Nin)) fd &= fb.Nin(x => x.PersonType.Code, filter.PersonType.Code.Nin);
if (fu.Assert(filter.PersonType.Code.Gt)) fd &= fb.Gt(x => x.PersonType.Code, filter.PersonType.Code.Gt);
if (fu.Assert(filter.PersonType.Code.Gte)) fd &= fb.Gte(x => x.PersonType.Code, filter.PersonType.Code.Gte);
if (fu.Assert(filter.PersonType.Code.Lt)) fd &= fb.Lt(x => x.PersonType.Code, filter.PersonType.Code.Lt);
if (fu.Assert(filter.PersonType.Code.Lte)) fd &= fb.Lte(x => x.PersonType.Code, filter.PersonType.Code.Lte);
}

if (filter.PersonType.Name is not null)
{
if (fu.Assert(filter.PersonType.Name.Eq)) fd &= fb.Eq(x => x.PersonType.Name, filter.PersonType.Name.Eq);
if (fu.Assert(filter.PersonType.Name.Ne)) fd &= fb.Ne(x => x.PersonType.Name, filter.PersonType.Name.Ne);
if (fu.Assert(filter.PersonType.Name.St)) fd &= fb.Regex(x => x.PersonType.Name, RegexFunctions.St(filter.PersonType.Name.St));
if (fu.Assert(filter.PersonType.Name.Ed)) fd &= fb.Regex(x => x.PersonType.Name, RegexFunctions.Ed(filter.PersonType.Name.Ed));
if (fu.Assert(filter.PersonType.Name.Nst)) fd &= fb.Regex(x => x.PersonType.Name, RegexFunctions.Nst(filter.PersonType.Name.Nst));
if (fu.Assert(filter.PersonType.Name.Ned)) fd &= fb.Regex(x => x.PersonType.Name, RegexFunctions.Ned(filter.PersonType.Name.Ned));
if (fu.Assert(filter.PersonType.Name.Regex)) fd &= fb.Regex(x => x.PersonType.Name, RegexFunctions.Regex(filter.PersonType.Name.Regex));
}
}

if (filter.IdentityType is not null)
{
if (filter.IdentityType.Code is not null)
{
if (fu.Assert(filter.IdentityType.Code.Eq)) fd &= fb.Eq(x => x.IdentityType.Code, filter.IdentityType.Code.Eq);
if (fu.Assert(filter.IdentityType.Code.Ne)) fd &= fb.Ne(x => x.IdentityType.Code, filter.IdentityType.Code.Ne);
if (fu.Assert(filter.IdentityType.Code.In)) fd &= fb.In(x => x.IdentityType.Code, filter.IdentityType.Code.In);
if (fu.Assert(filter.IdentityType.Code.Nin)) fd &= fb.Nin(x => x.IdentityType.Code, filter.IdentityType.Code.Nin);
if (fu.Assert(filter.IdentityType.Code.Gt)) fd &= fb.Gt(x => x.IdentityType.Code, filter.IdentityType.Code.Gt);
if (fu.Assert(filter.IdentityType.Code.Gte)) fd &= fb.Gte(x => x.IdentityType.Code, filter.IdentityType.Code.Gte);
if (fu.Assert(filter.IdentityType.Code.Lt)) fd &= fb.Lt(x => x.IdentityType.Code, filter.IdentityType.Code.Lt);
if (fu.Assert(filter.IdentityType.Code.Lte)) fd &= fb.Lte(x => x.IdentityType.Code, filter.IdentityType.Code.Lte);
}

if (filter.IdentityType.Name is not null)
{
if (fu.Assert(filter.IdentityType.Name.Eq)) fd &= fb.Eq(x => x.IdentityType.Name, filter.IdentityType.Name.Eq);
if (fu.Assert(filter.IdentityType.Name.Ne)) fd &= fb.Ne(x => x.IdentityType.Name, filter.IdentityType.Name.Ne);
if (fu.Assert(filter.IdentityType.Name.St)) fd &= fb.Regex(x => x.IdentityType.Name, RegexFunctions.St(filter.IdentityType.Name.St));
if (fu.Assert(filter.IdentityType.Name.Ed)) fd &= fb.Regex(x => x.IdentityType.Name, RegexFunctions.Ed(filter.IdentityType.Name.Ed));
if (fu.Assert(filter.IdentityType.Name.Nst)) fd &= fb.Regex(x => x.IdentityType.Name, RegexFunctions.Nst(filter.IdentityType.Name.Nst));
if (fu.Assert(filter.IdentityType.Name.Ned)) fd &= fb.Regex(x => x.IdentityType.Name, RegexFunctions.Ned(filter.IdentityType.Name.Ned));
if (fu.Assert(filter.IdentityType.Name.Regex)) fd &= fb.Regex(x => x.IdentityType.Name, RegexFunctions.Regex(filter.IdentityType.Name.Regex));
}
}

if (filter.Identity is not null)
{
if (fu.Assert(filter.Identity.Eq)) fd &= fb.Eq(x => x.Identity, filter.Identity.Eq);
if (fu.Assert(filter.Identity.Ne)) fd &= fb.Ne(x => x.Identity, filter.Identity.Ne);
if (fu.Assert(filter.Identity.St)) fd &= fb.Regex(x => x.Identity, RegexFunctions.St(filter.Identity.St));
if (fu.Assert(filter.Identity.Ed)) fd &= fb.Regex(x => x.Identity, RegexFunctions.Ed(filter.Identity.Ed));
if (fu.Assert(filter.Identity.Nst)) fd &= fb.Regex(x => x.Identity, RegexFunctions.Nst(filter.Identity.Nst));
if (fu.Assert(filter.Identity.Ned)) fd &= fb.Regex(x => x.Identity, RegexFunctions.Ned(filter.Identity.Ned));
if (fu.Assert(filter.Identity.Regex)) fd &= fb.Regex(x => x.Identity, RegexFunctions.Regex(filter.Identity.Regex));
}

if (filter.BirthDate is not null)
{
var day = fu.GetStartEndDay(filter.BirthDate.Eq, credential.TimeZoneInfo);
if (day  is not null) fd &= fb.Gte(x => x.BirthDate, day.Value.Start) & fb.Lte(x => x.BirthDate, day.Value.End);

day = fu.GetStartEndDay(filter.BirthDate.Ne, credential.TimeZoneInfo);
if (day  is not null) fd &= (fb.Lt(x => x.BirthDate, day.Value.Start) | fb.Gt(x => x.BirthDate, day.Value.End) | fb.Eq(x => x.BirthDate, null));

var dt = fu.GetDate(filter.BirthDate.Gt, credential.TimeZoneInfo);
if (dt  is not null) fd &= fb.Gt(x => x.BirthDate, dt);

dt = fu.GetDate(filter.BirthDate.Lt, credential.TimeZoneInfo);
if (dt  is not null) fd &= fb.Lt(x => x.BirthDate, dt);

dt = fu.GetDate(filter.BirthDate.Gte, credential.TimeZoneInfo);
if (dt  is not null) fd &= fb.Gte(x => x.BirthDate, dt);

dt = fu.GetDate(filter.BirthDate.Lte, credential.TimeZoneInfo);
if (dt  is not null) fd &= fb.Lte(x => x.BirthDate, dt);
}

if (filter.Status is not null)
{
if (filter.Status.Code is not null)
{
if (fu.Assert(filter.Status.Code.Eq)) fd &= fb.Eq(x => x.Status.Code, filter.Status.Code.Eq);
if (fu.Assert(filter.Status.Code.Ne)) fd &= fb.Ne(x => x.Status.Code, filter.Status.Code.Ne);
if (fu.Assert(filter.Status.Code.In)) fd &= fb.In(x => x.Status.Code, filter.Status.Code.In);
if (fu.Assert(filter.Status.Code.Nin)) fd &= fb.Nin(x => x.Status.Code, filter.Status.Code.Nin);
if (fu.Assert(filter.Status.Code.Gt)) fd &= fb.Gt(x => x.Status.Code, filter.Status.Code.Gt);
if (fu.Assert(filter.Status.Code.Gte)) fd &= fb.Gte(x => x.Status.Code, filter.Status.Code.Gte);
if (fu.Assert(filter.Status.Code.Lt)) fd &= fb.Lt(x => x.Status.Code, filter.Status.Code.Lt);
if (fu.Assert(filter.Status.Code.Lte)) fd &= fb.Lte(x => x.Status.Code, filter.Status.Code.Lte);
}

if (filter.Status.Name is not null)
{
if (fu.Assert(filter.Status.Name.Eq)) fd &= fb.Eq(x => x.Status.Name, filter.Status.Name.Eq);
if (fu.Assert(filter.Status.Name.Ne)) fd &= fb.Ne(x => x.Status.Name, filter.Status.Name.Ne);
if (fu.Assert(filter.Status.Name.St)) fd &= fb.Regex(x => x.Status.Name, RegexFunctions.St(filter.Status.Name.St));
if (fu.Assert(filter.Status.Name.Ed)) fd &= fb.Regex(x => x.Status.Name, RegexFunctions.Ed(filter.Status.Name.Ed));
if (fu.Assert(filter.Status.Name.Nst)) fd &= fb.Regex(x => x.Status.Name, RegexFunctions.Nst(filter.Status.Name.Nst));
if (fu.Assert(filter.Status.Name.Ned)) fd &= fb.Regex(x => x.Status.Name, RegexFunctions.Ned(filter.Status.Name.Ned));
if (fu.Assert(filter.Status.Name.Regex)) fd &= fb.Regex(x => x.Status.Name, RegexFunctions.Regex(filter.Status.Name.Regex));
}

if (filter.Status.Date is not null)
{
var day = fu.GetStartEndDay(filter.Status.Date.Eq, credential.TimeZoneInfo);
if (day  is not null) fd &= fb.Gte(x => x.Status.Date, day.Value.Start) & fb.Lte(x => x.Status.Date, day.Value.End);

day = fu.GetStartEndDay(filter.Status.Date.Ne, credential.TimeZoneInfo);
if (day  is not null) fd &= (fb.Lt(x => x.Status.Date, day.Value.Start) | fb.Gt(x => x.Status.Date, day.Value.End) | fb.Eq(x => x.Status.Date, null));

var dt = fu.GetDate(filter.Status.Date.Gt, credential.TimeZoneInfo);
if (dt  is not null) fd &= fb.Gt(x => x.Status.Date, dt);

dt = fu.GetDate(filter.Status.Date.Lt, credential.TimeZoneInfo);
if (dt  is not null) fd &= fb.Lt(x => x.Status.Date, dt);

dt = fu.GetDate(filter.Status.Date.Gte, credential.TimeZoneInfo);
if (dt  is not null) fd &= fb.Gte(x => x.Status.Date, dt);

dt = fu.GetDate(filter.Status.Date.Lte, credential.TimeZoneInfo);
if (dt  is not null) fd &= fb.Lte(x => x.Status.Date, dt);
}

if (filter.Status.Color is not null)
{
if (fu.Assert(filter.Status.Color.Eq)) fd &= fb.Eq(x => x.Status.Color, filter.Status.Color.Eq);
if (fu.Assert(filter.Status.Color.Ne)) fd &= fb.Ne(x => x.Status.Color, filter.Status.Color.Ne);
if (fu.Assert(filter.Status.Color.St)) fd &= fb.Regex(x => x.Status.Color, RegexFunctions.St(filter.Status.Color.St));
if (fu.Assert(filter.Status.Color.Ed)) fd &= fb.Regex(x => x.Status.Color, RegexFunctions.Ed(filter.Status.Color.Ed));
if (fu.Assert(filter.Status.Color.Nst)) fd &= fb.Regex(x => x.Status.Color, RegexFunctions.Nst(filter.Status.Color.Nst));
if (fu.Assert(filter.Status.Color.Ned)) fd &= fb.Regex(x => x.Status.Color, RegexFunctions.Ned(filter.Status.Color.Ned));
if (fu.Assert(filter.Status.Color.Regex)) fd &= fb.Regex(x => x.Status.Color, RegexFunctions.Regex(filter.Status.Color.Regex));
}

if (filter.Status.Note is not null)
{
if (fu.Assert(filter.Status.Note.Eq)) fd &= fb.Eq(x => x.Status.Note, filter.Status.Note.Eq);
if (fu.Assert(filter.Status.Note.Ne)) fd &= fb.Ne(x => x.Status.Note, filter.Status.Note.Ne);
if (fu.Assert(filter.Status.Note.St)) fd &= fb.Regex(x => x.Status.Note, RegexFunctions.St(filter.Status.Note.St));
if (fu.Assert(filter.Status.Note.Ed)) fd &= fb.Regex(x => x.Status.Note, RegexFunctions.Ed(filter.Status.Note.Ed));
if (fu.Assert(filter.Status.Note.Nst)) fd &= fb.Regex(x => x.Status.Note, RegexFunctions.Nst(filter.Status.Note.Nst));
if (fu.Assert(filter.Status.Note.Ned)) fd &= fb.Regex(x => x.Status.Note, RegexFunctions.Ned(filter.Status.Note.Ned));
if (fu.Assert(filter.Status.Note.Regex)) fd &= fb.Regex(x => x.Status.Note, RegexFunctions.Regex(filter.Status.Note.Regex));
}
}

if (fu.Assert(filter.Enabled?.Eq)) fd &= fb.Eq(x => x.Enabled, filter.Enabled.Eq);
if (fu.Assert(filter.Enabled?.Ne)) fd &= fb.Ne(x => x.Enabled, filter.Enabled.Ne);

if (fu.Assert(filter.TagCodes?.In)) fd &= fb.AnyIn(x => x.TagCodes, filter.TagCodes.In);
if (fu.Assert(filter.TagCodes?.Nin)) fd &= fb.AnyNin(x => x.TagCodes, filter.TagCodes.Nin);

if (filter.Parent is not null)
{
if (filter.Parent.Id is not null)
{
if (fu.Assert(filter.Parent.Id.Eq?.ToNullableGuid())) fd &= fb.Eq(x => x.Parent.Id, filter.Parent.Id.Eq.ToGuid());
if (fu.Assert(filter.Parent.Id.Ne?.ToNullableGuid())) fd &= fb.Ne(x => x.Parent.Id, filter.Parent.Id.Ne.ToGuid());
if (fu.Assert(filter.Parent.Id.In?.ToListGuid())) fd &= fb.In(x => x.Parent.Id, filter.Parent.Id.In?.ToListGuid());
if (fu.Assert(filter.Parent.Id.Nin?.ToListGuid())) fd &= fb.Nin(x => x.Parent.Id, filter.Parent.Id.Nin?.ToListGuid());
}

if (filter.Parent.Code is not null)
{
if (fu.Assert(filter.Parent.Code.Eq)) fd &= fb.Eq(x => x.Parent.Code, filter.Parent.Code.Eq);
if (fu.Assert(filter.Parent.Code.Ne)) fd &= fb.Ne(x => x.Parent.Code, filter.Parent.Code.Ne);
if (fu.Assert(filter.Parent.Code.In)) fd &= fb.In(x => x.Parent.Code, filter.Parent.Code.In);
if (fu.Assert(filter.Parent.Code.Nin)) fd &= fb.Nin(x => x.Parent.Code, filter.Parent.Code.Nin);
if (fu.Assert(filter.Parent.Code.Gt)) fd &= fb.Gt(x => x.Parent.Code, filter.Parent.Code.Gt);
if (fu.Assert(filter.Parent.Code.Gte)) fd &= fb.Gte(x => x.Parent.Code, filter.Parent.Code.Gte);
if (fu.Assert(filter.Parent.Code.Lt)) fd &= fb.Lt(x => x.Parent.Code, filter.Parent.Code.Lt);
if (fu.Assert(filter.Parent.Code.Lte)) fd &= fb.Lte(x => x.Parent.Code, filter.Parent.Code.Lte);
}

if (filter.Parent.Name is not null)
{
if (fu.Assert(filter.Parent.Name.Eq)) fd &= fb.Eq(x => x.Parent.Name, filter.Parent.Name.Eq);
if (fu.Assert(filter.Parent.Name.Ne)) fd &= fb.Ne(x => x.Parent.Name, filter.Parent.Name.Ne);
if (fu.Assert(filter.Parent.Name.St)) fd &= fb.Regex(x => x.Parent.Name, RegexFunctions.St(filter.Parent.Name.St));
if (fu.Assert(filter.Parent.Name.Ed)) fd &= fb.Regex(x => x.Parent.Name, RegexFunctions.Ed(filter.Parent.Name.Ed));
if (fu.Assert(filter.Parent.Name.Nst)) fd &= fb.Regex(x => x.Parent.Name, RegexFunctions.Nst(filter.Parent.Name.Nst));
if (fu.Assert(filter.Parent.Name.Ned)) fd &= fb.Regex(x => x.Parent.Name, RegexFunctions.Ned(filter.Parent.Name.Ned));
if (fu.Assert(filter.Parent.Name.Regex)) fd &= fb.Regex(x => x.Parent.Name, RegexFunctions.Regex(filter.Parent.Name.Regex));
}
}

if (filter.Avatar is not null)
{
if (fu.Assert(filter.Avatar.Eq)) fd &= fb.Eq(x => x.Avatar, filter.Avatar.Eq);
if (fu.Assert(filter.Avatar.Ne)) fd &= fb.Ne(x => x.Avatar, filter.Avatar.Ne);
if (fu.Assert(filter.Avatar.St)) fd &= fb.Regex(x => x.Avatar, RegexFunctions.St(filter.Avatar.St));
if (fu.Assert(filter.Avatar.Ed)) fd &= fb.Regex(x => x.Avatar, RegexFunctions.Ed(filter.Avatar.Ed));
if (fu.Assert(filter.Avatar.Nst)) fd &= fb.Regex(x => x.Avatar, RegexFunctions.Nst(filter.Avatar.Nst));
if (fu.Assert(filter.Avatar.Ned)) fd &= fb.Regex(x => x.Avatar, RegexFunctions.Ned(filter.Avatar.Ned));
if (fu.Assert(filter.Avatar.Regex)) fd &= fb.Regex(x => x.Avatar, RegexFunctions.Regex(filter.Avatar.Regex));
}

if (filter.Image is not null)
{
if (fu.Assert(filter.Image.Eq)) fd &= fb.Eq(x => x.Image, filter.Image.Eq);
if (fu.Assert(filter.Image.Ne)) fd &= fb.Ne(x => x.Image, filter.Image.Ne);
if (fu.Assert(filter.Image.St)) fd &= fb.Regex(x => x.Image, RegexFunctions.St(filter.Image.St));
if (fu.Assert(filter.Image.Ed)) fd &= fb.Regex(x => x.Image, RegexFunctions.Ed(filter.Image.Ed));
if (fu.Assert(filter.Image.Nst)) fd &= fb.Regex(x => x.Image, RegexFunctions.Nst(filter.Image.Nst));
if (fu.Assert(filter.Image.Ned)) fd &= fb.Regex(x => x.Image, RegexFunctions.Ned(filter.Image.Ned));
if (fu.Assert(filter.Image.Regex)) fd &= fb.Regex(x => x.Image, RegexFunctions.Regex(filter.Image.Regex));
}

if (filter.Color is not null)
{
if (fu.Assert(filter.Color.Eq)) fd &= fb.Eq(x => x.Color, filter.Color.Eq);
if (fu.Assert(filter.Color.Ne)) fd &= fb.Ne(x => x.Color, filter.Color.Ne);
if (fu.Assert(filter.Color.St)) fd &= fb.Regex(x => x.Color, RegexFunctions.St(filter.Color.St));
if (fu.Assert(filter.Color.Ed)) fd &= fb.Regex(x => x.Color, RegexFunctions.Ed(filter.Color.Ed));
if (fu.Assert(filter.Color.Nst)) fd &= fb.Regex(x => x.Color, RegexFunctions.Nst(filter.Color.Nst));
if (fu.Assert(filter.Color.Ned)) fd &= fb.Regex(x => x.Color, RegexFunctions.Ned(filter.Color.Ned));
if (fu.Assert(filter.Color.Regex)) fd &= fb.Regex(x => x.Color, RegexFunctions.Regex(filter.Color.Regex));
}

if (filter.ReferenceCode is not null)
{
if (fu.Assert(filter.ReferenceCode.Eq)) fd &= fb.Eq(x => x.ReferenceCode, filter.ReferenceCode.Eq);
if (fu.Assert(filter.ReferenceCode.Ne)) fd &= fb.Ne(x => x.ReferenceCode, filter.ReferenceCode.Ne);
if (fu.Assert(filter.ReferenceCode.St)) fd &= fb.Regex(x => x.ReferenceCode, RegexFunctions.St(filter.ReferenceCode.St));
if (fu.Assert(filter.ReferenceCode.Ed)) fd &= fb.Regex(x => x.ReferenceCode, RegexFunctions.Ed(filter.ReferenceCode.Ed));
if (fu.Assert(filter.ReferenceCode.Nst)) fd &= fb.Regex(x => x.ReferenceCode, RegexFunctions.Nst(filter.ReferenceCode.Nst));
if (fu.Assert(filter.ReferenceCode.Ned)) fd &= fb.Regex(x => x.ReferenceCode, RegexFunctions.Ned(filter.ReferenceCode.Ned));
if (fu.Assert(filter.ReferenceCode.Regex)) fd &= fb.Regex(x => x.ReferenceCode, RegexFunctions.Regex(filter.ReferenceCode.Regex));
}

if (filter.ExternalCode is not null)
{
if (fu.Assert(filter.ExternalCode.Eq)) fd &= fb.Eq(x => x.ExternalCode, filter.ExternalCode.Eq);
if (fu.Assert(filter.ExternalCode.Ne)) fd &= fb.Ne(x => x.ExternalCode, filter.ExternalCode.Ne);
if (fu.Assert(filter.ExternalCode.St)) fd &= fb.Regex(x => x.ExternalCode, RegexFunctions.St(filter.ExternalCode.St));
if (fu.Assert(filter.ExternalCode.Ed)) fd &= fb.Regex(x => x.ExternalCode, RegexFunctions.Ed(filter.ExternalCode.Ed));
if (fu.Assert(filter.ExternalCode.Nst)) fd &= fb.Regex(x => x.ExternalCode, RegexFunctions.Nst(filter.ExternalCode.Nst));
if (fu.Assert(filter.ExternalCode.Ned)) fd &= fb.Regex(x => x.ExternalCode, RegexFunctions.Ned(filter.ExternalCode.Ned));
if (fu.Assert(filter.ExternalCode.Regex)) fd &= fb.Regex(x => x.ExternalCode, RegexFunctions.Regex(filter.ExternalCode.Regex));
}

if (fu.Assert(filter.Ids?.In)) fd &= fb.AnyIn(x => x.Ids, filter.Ids.In);
if (fu.Assert(filter.Ids?.Nin)) fd &= fb.AnyNin(x => x.Ids, filter.Ids.Nin);

if (filter.Note is not null)
{
if (fu.Assert(filter.Note.Eq)) fd &= fb.Eq(x => x.Note, filter.Note.Eq);
if (fu.Assert(filter.Note.Ne)) fd &= fb.Ne(x => x.Note, filter.Note.Ne);
if (fu.Assert(filter.Note.St)) fd &= fb.Regex(x => x.Note, RegexFunctions.St(filter.Note.St));
if (fu.Assert(filter.Note.Ed)) fd &= fb.Regex(x => x.Note, RegexFunctions.Ed(filter.Note.Ed));
if (fu.Assert(filter.Note.Nst)) fd &= fb.Regex(x => x.Note, RegexFunctions.Nst(filter.Note.Nst));
if (fu.Assert(filter.Note.Ned)) fd &= fb.Regex(x => x.Note, RegexFunctions.Ned(filter.Note.Ned));
if (fu.Assert(filter.Note.Regex)) fd &= fb.Regex(x => x.Note, RegexFunctions.Regex(filter.Note.Regex));
}

if (filter.Dealer is not null)
{
if (filter.Dealer.Id is not null)
{
if (fu.Assert(filter.Dealer.Id.Eq?.ToNullableGuid())) fd &= fb.Eq(x => x.Dealer.Id, filter.Dealer.Id.Eq.ToGuid());
if (fu.Assert(filter.Dealer.Id.Ne?.ToNullableGuid())) fd &= fb.Ne(x => x.Dealer.Id, filter.Dealer.Id.Ne.ToGuid());
if (fu.Assert(filter.Dealer.Id.In?.ToListGuid())) fd &= fb.In(x => x.Dealer.Id, filter.Dealer.Id.In?.ToListGuid());
if (fu.Assert(filter.Dealer.Id.Nin?.ToListGuid())) fd &= fb.Nin(x => x.Dealer.Id, filter.Dealer.Id.Nin?.ToListGuid());
}

if (filter.Dealer.Code is not null)
{
if (fu.Assert(filter.Dealer.Code.Eq)) fd &= fb.Eq(x => x.Dealer.Code, filter.Dealer.Code.Eq);
if (fu.Assert(filter.Dealer.Code.Ne)) fd &= fb.Ne(x => x.Dealer.Code, filter.Dealer.Code.Ne);
if (fu.Assert(filter.Dealer.Code.In)) fd &= fb.In(x => x.Dealer.Code, filter.Dealer.Code.In);
if (fu.Assert(filter.Dealer.Code.Nin)) fd &= fb.Nin(x => x.Dealer.Code, filter.Dealer.Code.Nin);
if (fu.Assert(filter.Dealer.Code.Gt)) fd &= fb.Gt(x => x.Dealer.Code, filter.Dealer.Code.Gt);
if (fu.Assert(filter.Dealer.Code.Gte)) fd &= fb.Gte(x => x.Dealer.Code, filter.Dealer.Code.Gte);
if (fu.Assert(filter.Dealer.Code.Lt)) fd &= fb.Lt(x => x.Dealer.Code, filter.Dealer.Code.Lt);
if (fu.Assert(filter.Dealer.Code.Lte)) fd &= fb.Lte(x => x.Dealer.Code, filter.Dealer.Code.Lte);
}

if (filter.Dealer.Name is not null)
{
if (fu.Assert(filter.Dealer.Name.Eq)) fd &= fb.Eq(x => x.Dealer.Name, filter.Dealer.Name.Eq);
if (fu.Assert(filter.Dealer.Name.Ne)) fd &= fb.Ne(x => x.Dealer.Name, filter.Dealer.Name.Ne);
if (fu.Assert(filter.Dealer.Name.St)) fd &= fb.Regex(x => x.Dealer.Name, RegexFunctions.St(filter.Dealer.Name.St));
if (fu.Assert(filter.Dealer.Name.Ed)) fd &= fb.Regex(x => x.Dealer.Name, RegexFunctions.Ed(filter.Dealer.Name.Ed));
if (fu.Assert(filter.Dealer.Name.Nst)) fd &= fb.Regex(x => x.Dealer.Name, RegexFunctions.Nst(filter.Dealer.Name.Nst));
if (fu.Assert(filter.Dealer.Name.Ned)) fd &= fb.Regex(x => x.Dealer.Name, RegexFunctions.Ned(filter.Dealer.Name.Ned));
if (fu.Assert(filter.Dealer.Name.Regex)) fd &= fb.Regex(x => x.Dealer.Name, RegexFunctions.Regex(filter.Dealer.Name.Regex));
}
}

if (filter.Company is not null)
{
if (filter.Company.Id is not null)
{
if (fu.Assert(filter.Company.Id.Eq?.ToNullableGuid())) fd &= fb.Eq(x => x.Company.Id, filter.Company.Id.Eq.ToGuid());
if (fu.Assert(filter.Company.Id.Ne?.ToNullableGuid())) fd &= fb.Ne(x => x.Company.Id, filter.Company.Id.Ne.ToGuid());
if (fu.Assert(filter.Company.Id.In?.ToListGuid())) fd &= fb.In(x => x.Company.Id, filter.Company.Id.In?.ToListGuid());
if (fu.Assert(filter.Company.Id.Nin?.ToListGuid())) fd &= fb.Nin(x => x.Company.Id, filter.Company.Id.Nin?.ToListGuid());
}

if (filter.Company.Code is not null)
{
if (fu.Assert(filter.Company.Code.Eq)) fd &= fb.Eq(x => x.Company.Code, filter.Company.Code.Eq);
if (fu.Assert(filter.Company.Code.Ne)) fd &= fb.Ne(x => x.Company.Code, filter.Company.Code.Ne);
if (fu.Assert(filter.Company.Code.In)) fd &= fb.In(x => x.Company.Code, filter.Company.Code.In);
if (fu.Assert(filter.Company.Code.Nin)) fd &= fb.Nin(x => x.Company.Code, filter.Company.Code.Nin);
if (fu.Assert(filter.Company.Code.Gt)) fd &= fb.Gt(x => x.Company.Code, filter.Company.Code.Gt);
if (fu.Assert(filter.Company.Code.Gte)) fd &= fb.Gte(x => x.Company.Code, filter.Company.Code.Gte);
if (fu.Assert(filter.Company.Code.Lt)) fd &= fb.Lt(x => x.Company.Code, filter.Company.Code.Lt);
if (fu.Assert(filter.Company.Code.Lte)) fd &= fb.Lte(x => x.Company.Code, filter.Company.Code.Lte);
}

if (filter.Company.Name is not null)
{
if (fu.Assert(filter.Company.Name.Eq)) fd &= fb.Eq(x => x.Company.Name, filter.Company.Name.Eq);
if (fu.Assert(filter.Company.Name.Ne)) fd &= fb.Ne(x => x.Company.Name, filter.Company.Name.Ne);
if (fu.Assert(filter.Company.Name.St)) fd &= fb.Regex(x => x.Company.Name, RegexFunctions.St(filter.Company.Name.St));
if (fu.Assert(filter.Company.Name.Ed)) fd &= fb.Regex(x => x.Company.Name, RegexFunctions.Ed(filter.Company.Name.Ed));
if (fu.Assert(filter.Company.Name.Nst)) fd &= fb.Regex(x => x.Company.Name, RegexFunctions.Nst(filter.Company.Name.Nst));
if (fu.Assert(filter.Company.Name.Ned)) fd &= fb.Regex(x => x.Company.Name, RegexFunctions.Ned(filter.Company.Name.Ned));
if (fu.Assert(filter.Company.Name.Regex)) fd &= fb.Regex(x => x.Company.Name, RegexFunctions.Regex(filter.Company.Name.Regex));
}
}

if (filter.Account is not null)
{
if (filter.Account.Id is not null)
{
if (fu.Assert(filter.Account.Id.Eq?.ToNullableGuid())) fd &= fb.Eq(x => x.Account.Id, filter.Account.Id.Eq.ToGuid());
if (fu.Assert(filter.Account.Id.Ne?.ToNullableGuid())) fd &= fb.Ne(x => x.Account.Id, filter.Account.Id.Ne.ToGuid());
if (fu.Assert(filter.Account.Id.In?.ToListGuid())) fd &= fb.In(x => x.Account.Id, filter.Account.Id.In?.ToListGuid());
if (fu.Assert(filter.Account.Id.Nin?.ToListGuid())) fd &= fb.Nin(x => x.Account.Id, filter.Account.Id.Nin?.ToListGuid());
}

if (filter.Account.Code is not null)
{
if (fu.Assert(filter.Account.Code.Eq)) fd &= fb.Eq(x => x.Account.Code, filter.Account.Code.Eq);
if (fu.Assert(filter.Account.Code.Ne)) fd &= fb.Ne(x => x.Account.Code, filter.Account.Code.Ne);
if (fu.Assert(filter.Account.Code.In)) fd &= fb.In(x => x.Account.Code, filter.Account.Code.In);
if (fu.Assert(filter.Account.Code.Nin)) fd &= fb.Nin(x => x.Account.Code, filter.Account.Code.Nin);
if (fu.Assert(filter.Account.Code.Gt)) fd &= fb.Gt(x => x.Account.Code, filter.Account.Code.Gt);
if (fu.Assert(filter.Account.Code.Gte)) fd &= fb.Gte(x => x.Account.Code, filter.Account.Code.Gte);
if (fu.Assert(filter.Account.Code.Lt)) fd &= fb.Lt(x => x.Account.Code, filter.Account.Code.Lt);
if (fu.Assert(filter.Account.Code.Lte)) fd &= fb.Lte(x => x.Account.Code, filter.Account.Code.Lte);
}

if (filter.Account.Name is not null)
{
if (fu.Assert(filter.Account.Name.Eq)) fd &= fb.Eq(x => x.Account.Name, filter.Account.Name.Eq);
if (fu.Assert(filter.Account.Name.Ne)) fd &= fb.Ne(x => x.Account.Name, filter.Account.Name.Ne);
if (fu.Assert(filter.Account.Name.St)) fd &= fb.Regex(x => x.Account.Name, RegexFunctions.St(filter.Account.Name.St));
if (fu.Assert(filter.Account.Name.Ed)) fd &= fb.Regex(x => x.Account.Name, RegexFunctions.Ed(filter.Account.Name.Ed));
if (fu.Assert(filter.Account.Name.Nst)) fd &= fb.Regex(x => x.Account.Name, RegexFunctions.Nst(filter.Account.Name.Nst));
if (fu.Assert(filter.Account.Name.Ned)) fd &= fb.Regex(x => x.Account.Name, RegexFunctions.Ned(filter.Account.Name.Ned));
if (fu.Assert(filter.Account.Name.Regex)) fd &= fb.Regex(x => x.Account.Name, RegexFunctions.Regex(filter.Account.Name.Regex));
}
}

if (filter.Partner is not null)
{
if (filter.Partner.Id is not null)
{
if (fu.Assert(filter.Partner.Id.Eq?.ToNullableGuid())) fd &= fb.Eq(x => x.Partner.Id, filter.Partner.Id.Eq.ToGuid());
if (fu.Assert(filter.Partner.Id.Ne?.ToNullableGuid())) fd &= fb.Ne(x => x.Partner.Id, filter.Partner.Id.Ne.ToGuid());
if (fu.Assert(filter.Partner.Id.In?.ToListGuid())) fd &= fb.In(x => x.Partner.Id, filter.Partner.Id.In?.ToListGuid());
if (fu.Assert(filter.Partner.Id.Nin?.ToListGuid())) fd &= fb.Nin(x => x.Partner.Id, filter.Partner.Id.Nin?.ToListGuid());
}

if (filter.Partner.Code is not null)
{
if (fu.Assert(filter.Partner.Code.Eq)) fd &= fb.Eq(x => x.Partner.Code, filter.Partner.Code.Eq);
if (fu.Assert(filter.Partner.Code.Ne)) fd &= fb.Ne(x => x.Partner.Code, filter.Partner.Code.Ne);
if (fu.Assert(filter.Partner.Code.In)) fd &= fb.In(x => x.Partner.Code, filter.Partner.Code.In);
if (fu.Assert(filter.Partner.Code.Nin)) fd &= fb.Nin(x => x.Partner.Code, filter.Partner.Code.Nin);
if (fu.Assert(filter.Partner.Code.Gt)) fd &= fb.Gt(x => x.Partner.Code, filter.Partner.Code.Gt);
if (fu.Assert(filter.Partner.Code.Gte)) fd &= fb.Gte(x => x.Partner.Code, filter.Partner.Code.Gte);
if (fu.Assert(filter.Partner.Code.Lt)) fd &= fb.Lt(x => x.Partner.Code, filter.Partner.Code.Lt);
if (fu.Assert(filter.Partner.Code.Lte)) fd &= fb.Lte(x => x.Partner.Code, filter.Partner.Code.Lte);
}

if (filter.Partner.Name is not null)
{
if (fu.Assert(filter.Partner.Name.Eq)) fd &= fb.Eq(x => x.Partner.Name, filter.Partner.Name.Eq);
if (fu.Assert(filter.Partner.Name.Ne)) fd &= fb.Ne(x => x.Partner.Name, filter.Partner.Name.Ne);
if (fu.Assert(filter.Partner.Name.St)) fd &= fb.Regex(x => x.Partner.Name, RegexFunctions.St(filter.Partner.Name.St));
if (fu.Assert(filter.Partner.Name.Ed)) fd &= fb.Regex(x => x.Partner.Name, RegexFunctions.Ed(filter.Partner.Name.Ed));
if (fu.Assert(filter.Partner.Name.Nst)) fd &= fb.Regex(x => x.Partner.Name, RegexFunctions.Nst(filter.Partner.Name.Nst));
if (fu.Assert(filter.Partner.Name.Ned)) fd &= fb.Regex(x => x.Partner.Name, RegexFunctions.Ned(filter.Partner.Name.Ned));
if (fu.Assert(filter.Partner.Name.Regex)) fd &= fb.Regex(x => x.Partner.Name, RegexFunctions.Regex(filter.Partner.Name.Regex));
}
}

if (filter.Store is not null)
{
if (filter.Store.Id is not null)
{
if (fu.Assert(filter.Store.Id.Eq?.ToNullableGuid())) fd &= fb.Eq(x => x.Store.Id, filter.Store.Id.Eq.ToGuid());
if (fu.Assert(filter.Store.Id.Ne?.ToNullableGuid())) fd &= fb.Ne(x => x.Store.Id, filter.Store.Id.Ne.ToGuid());
if (fu.Assert(filter.Store.Id.In?.ToListGuid())) fd &= fb.In(x => x.Store.Id, filter.Store.Id.In?.ToListGuid());
if (fu.Assert(filter.Store.Id.Nin?.ToListGuid())) fd &= fb.Nin(x => x.Store.Id, filter.Store.Id.Nin?.ToListGuid());
}

if (filter.Store.Code is not null)
{
if (fu.Assert(filter.Store.Code.Eq)) fd &= fb.Eq(x => x.Store.Code, filter.Store.Code.Eq);
if (fu.Assert(filter.Store.Code.Ne)) fd &= fb.Ne(x => x.Store.Code, filter.Store.Code.Ne);
if (fu.Assert(filter.Store.Code.In)) fd &= fb.In(x => x.Store.Code, filter.Store.Code.In);
if (fu.Assert(filter.Store.Code.Nin)) fd &= fb.Nin(x => x.Store.Code, filter.Store.Code.Nin);
if (fu.Assert(filter.Store.Code.Gt)) fd &= fb.Gt(x => x.Store.Code, filter.Store.Code.Gt);
if (fu.Assert(filter.Store.Code.Gte)) fd &= fb.Gte(x => x.Store.Code, filter.Store.Code.Gte);
if (fu.Assert(filter.Store.Code.Lt)) fd &= fb.Lt(x => x.Store.Code, filter.Store.Code.Lt);
if (fu.Assert(filter.Store.Code.Lte)) fd &= fb.Lte(x => x.Store.Code, filter.Store.Code.Lte);
}

if (filter.Store.Name is not null)
{
if (fu.Assert(filter.Store.Name.Eq)) fd &= fb.Eq(x => x.Store.Name, filter.Store.Name.Eq);
if (fu.Assert(filter.Store.Name.Ne)) fd &= fb.Ne(x => x.Store.Name, filter.Store.Name.Ne);
if (fu.Assert(filter.Store.Name.St)) fd &= fb.Regex(x => x.Store.Name, RegexFunctions.St(filter.Store.Name.St));
if (fu.Assert(filter.Store.Name.Ed)) fd &= fb.Regex(x => x.Store.Name, RegexFunctions.Ed(filter.Store.Name.Ed));
if (fu.Assert(filter.Store.Name.Nst)) fd &= fb.Regex(x => x.Store.Name, RegexFunctions.Nst(filter.Store.Name.Nst));
if (fu.Assert(filter.Store.Name.Ned)) fd &= fb.Regex(x => x.Store.Name, RegexFunctions.Ned(filter.Store.Name.Ned));
if (fu.Assert(filter.Store.Name.Regex)) fd &= fb.Regex(x => x.Store.Name, RegexFunctions.Regex(filter.Store.Name.Regex));
}
}

if (filter.Broker is not null)
{
if (filter.Broker.Id is not null)
{
if (fu.Assert(filter.Broker.Id.Eq?.ToNullableGuid())) fd &= fb.Eq(x => x.Broker.Id, filter.Broker.Id.Eq.ToGuid());
if (fu.Assert(filter.Broker.Id.Ne?.ToNullableGuid())) fd &= fb.Ne(x => x.Broker.Id, filter.Broker.Id.Ne.ToGuid());
if (fu.Assert(filter.Broker.Id.In?.ToListGuid())) fd &= fb.In(x => x.Broker.Id, filter.Broker.Id.In?.ToListGuid());
if (fu.Assert(filter.Broker.Id.Nin?.ToListGuid())) fd &= fb.Nin(x => x.Broker.Id, filter.Broker.Id.Nin?.ToListGuid());
}

if (filter.Broker.Code is not null)
{
if (fu.Assert(filter.Broker.Code.Eq)) fd &= fb.Eq(x => x.Broker.Code, filter.Broker.Code.Eq);
if (fu.Assert(filter.Broker.Code.Ne)) fd &= fb.Ne(x => x.Broker.Code, filter.Broker.Code.Ne);
if (fu.Assert(filter.Broker.Code.In)) fd &= fb.In(x => x.Broker.Code, filter.Broker.Code.In);
if (fu.Assert(filter.Broker.Code.Nin)) fd &= fb.Nin(x => x.Broker.Code, filter.Broker.Code.Nin);
if (fu.Assert(filter.Broker.Code.Gt)) fd &= fb.Gt(x => x.Broker.Code, filter.Broker.Code.Gt);
if (fu.Assert(filter.Broker.Code.Gte)) fd &= fb.Gte(x => x.Broker.Code, filter.Broker.Code.Gte);
if (fu.Assert(filter.Broker.Code.Lt)) fd &= fb.Lt(x => x.Broker.Code, filter.Broker.Code.Lt);
if (fu.Assert(filter.Broker.Code.Lte)) fd &= fb.Lte(x => x.Broker.Code, filter.Broker.Code.Lte);
}

if (filter.Broker.Name is not null)
{
if (fu.Assert(filter.Broker.Name.Eq)) fd &= fb.Eq(x => x.Broker.Name, filter.Broker.Name.Eq);
if (fu.Assert(filter.Broker.Name.Ne)) fd &= fb.Ne(x => x.Broker.Name, filter.Broker.Name.Ne);
if (fu.Assert(filter.Broker.Name.St)) fd &= fb.Regex(x => x.Broker.Name, RegexFunctions.St(filter.Broker.Name.St));
if (fu.Assert(filter.Broker.Name.Ed)) fd &= fb.Regex(x => x.Broker.Name, RegexFunctions.Ed(filter.Broker.Name.Ed));
if (fu.Assert(filter.Broker.Name.Nst)) fd &= fb.Regex(x => x.Broker.Name, RegexFunctions.Nst(filter.Broker.Name.Nst));
if (fu.Assert(filter.Broker.Name.Ned)) fd &= fb.Regex(x => x.Broker.Name, RegexFunctions.Ned(filter.Broker.Name.Ned));
if (fu.Assert(filter.Broker.Name.Regex)) fd &= fb.Regex(x => x.Broker.Name, RegexFunctions.Regex(filter.Broker.Name.Regex));
}
}

if (filter.Log is not null)
{
if (filter.Log.CreationDate is not null)
{
var day = fu.GetStartEndDay(filter.Log.CreationDate.Eq, credential.TimeZoneInfo);
if (day  is not null) fd &= fb.Gte(x => x.Log.CreationDate, day.Value.Start) & fb.Lte(x => x.Log.CreationDate, day.Value.End);

day = fu.GetStartEndDay(filter.Log.CreationDate.Ne, credential.TimeZoneInfo);
if (day  is not null) fd &= (fb.Lt(x => x.Log.CreationDate, day.Value.Start) | fb.Gt(x => x.Log.CreationDate, day.Value.End));

var dt = fu.GetDate(filter.Log.CreationDate.Gt, credential.TimeZoneInfo);
if (dt  is not null) fd &= fb.Gt(x => x.Log.CreationDate, dt);

dt = fu.GetDate(filter.Log.CreationDate.Lt, credential.TimeZoneInfo);
if (dt  is not null) fd &= fb.Lt(x => x.Log.CreationDate, dt);

dt = fu.GetDate(filter.Log.CreationDate.Gte, credential.TimeZoneInfo);
if (dt  is not null) fd &= fb.Gte(x => x.Log.CreationDate, dt);

dt = fu.GetDate(filter.Log.CreationDate.Lte, credential.TimeZoneInfo);
if (dt  is not null) fd &= fb.Lte(x => x.Log.CreationDate, dt);
}

if (filter.Log.CreationUser is not null)
{
if (filter.Log.CreationUser.Id is not null)
{
if (fu.Assert(filter.Log.CreationUser.Id.Eq?.ToNullableGuid())) fd &= fb.Eq(x => x.Log.CreationUser.Id, filter.Log.CreationUser?.Id?.Eq.ToGuid());
if (fu.Assert(filter.Log.CreationUser.Id.Ne?.ToNullableGuid())) fd &= fb.Ne(x => x.Log.CreationUser.Id, filter.Log.CreationUser?.Id?.Ne.ToGuid());
if (fu.Assert(filter.Log.CreationUser.Id.In?.ToListGuid())) fd &= fb.In(x => x.Log.CreationUser.Id, filter.Log.CreationUser?.Id?.In?.ToListGuid());
if (fu.Assert(filter.Log.CreationUser.Id.Nin?.ToListGuid())) fd &= fb.Nin(x => x.Log.CreationUser.Id, filter.Log.CreationUser?.Id?.Nin?.ToListGuid());
}

if (filter.Log.CreationUser.Code is not null)
{
if (fu.Assert(filter.Log.CreationUser.Code.Eq)) fd &= fb.Eq(x => x.Log.CreationUser.Code, filter.Log.CreationUser?.Code?.Eq);
if (fu.Assert(filter.Log.CreationUser.Code.In)) fd &= fb.In(x => x.Log.CreationUser.Code, filter.Log.CreationUser?.Code?.In);
if (fu.Assert(filter.Log.CreationUser.Code.Nin)) fd &= fb.Nin(x => x.Log.CreationUser.Code, filter.Log.CreationUser?.Code?.Nin);
}

if (filter.Log.CreationUser.Name is not null)
{
if (fu.Assert(filter.Log.CreationUser.Name.Eq)) fd &= fb.Eq(x => x.Log.CreationUser.Name, filter.Log.CreationUser.Name.Eq);
if (fu.Assert(filter.Log.CreationUser.Name.Ne)) fd &= fb.Ne(x => x.Log.CreationUser.Name, filter.Log.CreationUser.Name.Ne);
if (fu.Assert(filter.Log.CreationUser.Name.St)) fd &= fb.Regex(x => x.Log.CreationUser.Name, RegexFunctions.St(filter.Log.CreationUser.Name.St));
if (fu.Assert(filter.Log.CreationUser.Name.Ed)) fd &= fb.Regex(x => x.Log.CreationUser.Name, RegexFunctions.Ed(filter.Log.CreationUser.Name.Ed));
if (fu.Assert(filter.Log.CreationUser.Name.Nst)) fd &= fb.Regex(x => x.Log.CreationUser.Name, RegexFunctions.Nst(filter.Log.CreationUser.Name.Nst));
if (fu.Assert(filter.Log.CreationUser.Name.Ned)) fd &= fb.Regex(x => x.Log.CreationUser.Name, RegexFunctions.Ned(filter.Log.CreationUser.Name.Ned));
if (fu.Assert(filter.Log.CreationUser.Name.Regex)) fd &= fb.Regex(x => x.Log.CreationUser.Name, RegexFunctions.Regex(filter.Log.CreationUser.Name.Regex));
}

}

if (filter.Log.ChangeDate is not null)
{
var day = fu.GetStartEndDay(filter.Log.ChangeDate.Eq, credential.TimeZoneInfo);
if (day  is not null) fd &= fb.Gte(x => x.Log.ChangeDate, day.Value.Start) & fb.Lte(x => x.Log.ChangeDate, day.Value.End);

day = fu.GetStartEndDay(filter.Log.ChangeDate.Ne, credential.TimeZoneInfo);
if (day  is not null) fd &= (fb.Lt(x => x.Log.ChangeDate, day.Value.Start) | fb.Gt(x => x.Log.ChangeDate, day.Value.End) | fb.Eq(x => x.Log.ChangeDate, null));

var dt = fu.GetDate(filter.Log.ChangeDate.Gt, credential.TimeZoneInfo);
if (dt  is not null) fd &= fb.Gt(x => x.Log.ChangeDate, dt);

dt = fu.GetDate(filter.Log.ChangeDate.Lt, credential.TimeZoneInfo);
if (dt  is not null) fd &= fb.Lt(x => x.Log.ChangeDate, dt);

dt = fu.GetDate(filter.Log.ChangeDate.Gte, credential.TimeZoneInfo);
if (dt  is not null) fd &= fb.Gte(x => x.Log.ChangeDate, dt);

dt = fu.GetDate(filter.Log.ChangeDate.Lte, credential.TimeZoneInfo);
if (dt  is not null) fd &= fb.Lte(x => x.Log.ChangeDate, dt);
}

if (filter.Log.ChangeUser is not null)
{
if (filter.Log.ChangeUser.Id is not null)
{
if (fu.Assert(filter.Log.ChangeUser.Id.Eq?.ToNullableGuid())) fd &= fb.Eq(x => x.Log.ChangeUser.Id, filter.Log.ChangeUser?.Id?.Eq.ToGuid());
if (fu.Assert(filter.Log.ChangeUser.Id.Ne?.ToNullableGuid())) fd &= fb.Ne(x => x.Log.ChangeUser.Id, filter.Log.ChangeUser?.Id?.Ne.ToGuid());
if (fu.Assert(filter.Log.ChangeUser.Id.In?.ToListGuid())) fd &= fb.In(x => x.Log.ChangeUser.Id, filter.Log.ChangeUser?.Id?.In?.ToListGuid());
if (fu.Assert(filter.Log.ChangeUser.Id.Nin?.ToListGuid())) fd &= fb.Nin(x => x.Log.ChangeUser.Id, filter.Log.ChangeUser?.Id?.Nin?.ToListGuid());
}

if (filter.Log.ChangeUser.Code is not null)
{
if (fu.Assert(filter.Log.ChangeUser.Code.Eq)) fd &= fb.Eq(x => x.Log.ChangeUser.Code, filter.Log.ChangeUser?.Code?.Eq);
if (fu.Assert(filter.Log.ChangeUser.Code.In)) fd &= fb.In(x => x.Log.ChangeUser.Code, filter.Log.ChangeUser?.Code?.In);
if (fu.Assert(filter.Log.ChangeUser.Code.Nin)) fd &= fb.Nin(x => x.Log.ChangeUser.Code, filter.Log.ChangeUser?.Code?.Nin);
}

if (filter.Log.ChangeUser.Name is not null)
{
if (fu.Assert(filter.Log.ChangeUser.Name.Eq)) fd &= fb.Eq(x => x.Log.ChangeUser.Name, filter.Log.ChangeUser.Name.Eq);
if (fu.Assert(filter.Log.ChangeUser.Name.Ne)) fd &= fb.Ne(x => x.Log.ChangeUser.Name, filter.Log.ChangeUser.Name.Ne);
if (fu.Assert(filter.Log.ChangeUser.Name.St)) fd &= fb.Regex(x => x.Log.ChangeUser.Name, RegexFunctions.St(filter.Log.ChangeUser.Name.St));
if (fu.Assert(filter.Log.ChangeUser.Name.Ed)) fd &= fb.Regex(x => x.Log.ChangeUser.Name, RegexFunctions.Ed(filter.Log.ChangeUser.Name.Ed));
if (fu.Assert(filter.Log.ChangeUser.Name.Nst)) fd &= fb.Regex(x => x.Log.ChangeUser.Name, RegexFunctions.Nst(filter.Log.ChangeUser.Name.Nst));
if (fu.Assert(filter.Log.ChangeUser.Name.Ned)) fd &= fb.Regex(x => x.Log.ChangeUser.Name, RegexFunctions.Ned(filter.Log.ChangeUser.Name.Ned));
if (fu.Assert(filter.Log.ChangeUser.Name.Regex)) fd &= fb.Regex(x => x.Log.ChangeUser.Name, RegexFunctions.Regex(filter.Log.ChangeUser.Name.Regex));
}

}

if (filter.Log.ExclusionDate is not null)
{
var day = fu.GetStartEndDay(filter.Log.ExclusionDate.Eq, credential.TimeZoneInfo);
if (day  is not null) fd &= fb.Gte(x => x.Log.ExclusionDate, day.Value.Start) & fb.Lte(x => x.Log.ExclusionDate, day.Value.End);

day = fu.GetStartEndDay(filter.Log.ExclusionDate.Ne, credential.TimeZoneInfo);
if (day  is not null) fd &= (fb.Lt(x => x.Log.ExclusionDate, day.Value.Start) | fb.Gt(x => x.Log.ExclusionDate, day.Value.End) | fb.Eq(x => x.Log.ExclusionDate, null));

var dt = fu.GetDate(filter.Log.ExclusionDate.Gt, credential.TimeZoneInfo);
if (dt  is not null) fd &= fb.Gt(x => x.Log.ExclusionDate, dt);

dt = fu.GetDate(filter.Log.ExclusionDate.Lt, credential.TimeZoneInfo);
if (dt  is not null) fd &= fb.Lt(x => x.Log.ExclusionDate, dt);

dt = fu.GetDate(filter.Log.ExclusionDate.Gte, credential.TimeZoneInfo);
if (dt  is not null) fd &= fb.Gte(x => x.Log.ExclusionDate, dt);

dt = fu.GetDate(filter.Log.ExclusionDate.Lte, credential.TimeZoneInfo);
if (dt  is not null) fd &= fb.Lte(x => x.Log.ExclusionDate, dt);
}

if (filter.Log.ExclusionUser is not null)
{
if (filter.Log.ExclusionUser.Id is not null)
{
if (fu.Assert(filter.Log.ExclusionUser.Id.Eq?.ToNullableGuid())) fd &= fb.Eq(x => x.Log.ExclusionUser.Id, filter.Log.ExclusionUser?.Id?.Eq.ToGuid());
if (fu.Assert(filter.Log.ExclusionUser.Id.Ne?.ToNullableGuid())) fd &= fb.Ne(x => x.Log.ExclusionUser.Id, filter.Log.ExclusionUser?.Id?.Ne.ToGuid());
if (fu.Assert(filter.Log.ExclusionUser.Id.In?.ToListGuid())) fd &= fb.In(x => x.Log.ExclusionUser.Id, filter.Log.ExclusionUser?.Id?.In?.ToListGuid());
if (fu.Assert(filter.Log.ExclusionUser.Id.Nin?.ToListGuid())) fd &= fb.Nin(x => x.Log.ExclusionUser.Id, filter.Log.ExclusionUser?.Id?.Nin?.ToListGuid());
}

if (filter.Log.ExclusionUser.Code is not null)
{
if (fu.Assert(filter.Log.ExclusionUser.Code.Eq)) fd &= fb.Eq(x => x.Log.ExclusionUser.Code, filter.Log.ExclusionUser?.Code?.Eq);
if (fu.Assert(filter.Log.ExclusionUser.Code.In)) fd &= fb.In(x => x.Log.ExclusionUser.Code, filter.Log.ExclusionUser?.Code?.In);
if (fu.Assert(filter.Log.ExclusionUser.Code.Nin)) fd &= fb.Nin(x => x.Log.ExclusionUser.Code, filter.Log.ExclusionUser?.Code?.Nin);
}

if (filter.Log.ExclusionUser.Name is not null)
{
if (fu.Assert(filter.Log.ExclusionUser.Name.Eq)) fd &= fb.Eq(x => x.Log.ExclusionUser.Name, filter.Log.ExclusionUser.Name.Eq);
if (fu.Assert(filter.Log.ExclusionUser.Name.Ne)) fd &= fb.Ne(x => x.Log.ExclusionUser.Name, filter.Log.ExclusionUser.Name.Ne);
if (fu.Assert(filter.Log.ExclusionUser.Name.St)) fd &= fb.Regex(x => x.Log.ExclusionUser.Name, RegexFunctions.St(filter.Log.ExclusionUser.Name.St));
if (fu.Assert(filter.Log.ExclusionUser.Name.Ed)) fd &= fb.Regex(x => x.Log.ExclusionUser.Name, RegexFunctions.Ed(filter.Log.ExclusionUser.Name.Ed));
if (fu.Assert(filter.Log.ExclusionUser.Name.Nst)) fd &= fb.Regex(x => x.Log.ExclusionUser.Name, RegexFunctions.Nst(filter.Log.ExclusionUser.Name.Nst));
if (fu.Assert(filter.Log.ExclusionUser.Name.Ned)) fd &= fb.Regex(x => x.Log.ExclusionUser.Name, RegexFunctions.Ned(filter.Log.ExclusionUser.Name.Ned));
if (fu.Assert(filter.Log.ExclusionUser.Name.Regex)) fd &= fb.Regex(x => x.Log.ExclusionUser.Name, RegexFunctions.Regex(filter.Log.ExclusionUser.Name.Regex));
}

}

if (filter.Log.VersionId is not null)
{
if (fu.Assert(filter.Log.VersionId.Eq?.ToNullableGuid())) fd &= fb.Eq(x => x.Log.VersionId, filter.Log.VersionId.Eq.ToGuid());
if (fu.Assert(filter.Log.VersionId.Ne?.ToNullableGuid())) fd &= fb.Ne(x => x.Log.VersionId, filter.Log.VersionId.Ne.ToGuid());
if (fu.Assert(filter.Log.VersionId.In?.ToListGuid())) fd &= fb.In(x => x.Log.VersionId, filter.Log.VersionId.In?.ToListGuid());
if (fu.Assert(filter.Log.VersionId.Nin?.ToListGuid())) fd &= fb.Nin(x => x.Log.VersionId, filter.Log.VersionId.Nin?.ToListGuid());
}

if (filter.Log.PreviousId is not null)
{
if (fu.Assert(filter.Log.PreviousId.Eq?.ToNullableGuid())) fd &= fb.Eq(x => x.Log.PreviousId, filter.Log.PreviousId.Eq.ToGuid());
if (fu.Assert(filter.Log.PreviousId.Ne?.ToNullableGuid())) fd &= fb.Ne(x => x.Log.PreviousId, filter.Log.PreviousId.Ne.ToGuid());
if (fu.Assert(filter.Log.PreviousId.In?.ToListGuid())) fd &= fb.In(x => x.Log.PreviousId, filter.Log.PreviousId.In?.ToListGuid());
if (fu.Assert(filter.Log.PreviousId.Nin?.ToListGuid())) fd &= fb.Nin(x => x.Log.PreviousId, filter.Log.PreviousId.Nin?.ToListGuid());
}

if (filter.Log.VersionDate is not null)
{
var day = fu.GetStartEndDay(filter.Log.VersionDate.Eq, credential.TimeZoneInfo);
if (day  is not null) fd &= fb.Gte(x => x.Log.VersionDate, day.Value.Start) & fb.Lte(x => x.Log.VersionDate, day.Value.End);

day = fu.GetStartEndDay(filter.Log.VersionDate.Ne, credential.TimeZoneInfo);
if (day  is not null) fd &= (fb.Lt(x => x.Log.VersionDate, day.Value.Start) | fb.Gt(x => x.Log.VersionDate, day.Value.End));

var dt = fu.GetDate(filter.Log.VersionDate.Gt, credential.TimeZoneInfo);
if (dt  is not null) fd &= fb.Gt(x => x.Log.VersionDate, dt);

dt = fu.GetDate(filter.Log.VersionDate.Lt, credential.TimeZoneInfo);
if (dt  is not null) fd &= fb.Lt(x => x.Log.VersionDate, dt);

dt = fu.GetDate(filter.Log.VersionDate.Gte, credential.TimeZoneInfo);
if (dt  is not null) fd &= fb.Gte(x => x.Log.VersionDate, dt);

dt = fu.GetDate(filter.Log.VersionDate.Lte, credential.TimeZoneInfo);
if (dt  is not null) fd &= fb.Lte(x => x.Log.VersionDate, dt);
}

}


return fd;
}

public FilterDefinition<Customer> GetLevel(CustomerLevelFilter filter)
{
var fb = Builders<Customer>.Filter;

var fd = fb.Where(_ => true);

if (filter is null)
return fd;

if (filter.All)
return fd;

var fu = new FilterUtil();
if (fu.Assert(filter.Ids)) fd &= fb.In(x => x.Id, filter.Ids);

if (fu.Assert(filter.DealerIds)) fd &= fb.In(x => x.Dealer.Id, filter.DealerIds);
if (fu.Assert(filter.AccountIds)) fd &= fb.In(x => x.Account.Id, filter.AccountIds);
if (fu.Assert(filter.PartnerIds)) fd &= fb.In(x => x.Partner.Id, filter.PartnerIds);
if (fu.Assert(filter.StoreIds)) fd &= fb.In(x => x.Store.Id, filter.StoreIds);
if (fu.Assert(filter.BrokerIds)) fd &= fb.In(x => x.Broker.Id, filter.BrokerIds);
if (fu.Assert(filter.StatusCodes)) fd &= fb.In(x => x.Status.Code, filter.StatusCodes);

return fd;
}

public void SetFilters(CustomerFilter filter)
{
filter.Filters ??= new List<FilterField>();

foreach (var item in filter.Filters)
{
if (item.Key == CustomerFilterField.SearchText)
{
filter.SearchText = item;
}
else if (item.Key == CustomerFilterField.Id)
{
filter.Id ??= new GuidFilter();
filter.Id.SetField(item);
}
else if (item.Key == CustomerFilterField.Code)
{
filter.Code ??= new IntFilter();
filter.Code.SetField(item);
}
else if (item.Key == CustomerFilterField.FeatureCode)
{
filter.Feature ??= new CodeNameFilter();
filter.Feature.Code ??= new IntFilter();
filter.Feature.Code.SetField(item);
}
else if (item.Key == CustomerFilterField.FeatureName)
{
filter.Feature ??= new CodeNameFilter();
filter.Feature.Name ??= new StringFilter();
filter.Feature.Name.SetField(item);
}
else if (item.Key == CustomerFilterField.TypeCode)
{
filter.Type ??= new CodeNameFilter();
filter.Type.Code ??= new IntFilter();
filter.Type.Code.SetField(item);
}
else if (item.Key == CustomerFilterField.TypeName)
{
filter.Type ??= new CodeNameFilter();
filter.Type.Name ??= new StringFilter();
filter.Type.Name.SetField(item);
}
else if (item.Key == CustomerFilterField.Name)
{
filter.Name ??= new StringFilter();
filter.Name.SetField(item);
}
else if (item.Key == CustomerFilterField.Nickname)
{
filter.Nickname ??= new StringFilter();
filter.Nickname.SetField(item);
}
else if (item.Key == CustomerFilterField.Description)
{
filter.Description ??= new StringFilter();
filter.Description.SetField(item);
}
else if (item.Key == CustomerFilterField.PersonTypeCode)
{
filter.PersonType ??= new CodeNameFilter();
filter.PersonType.Code ??= new IntFilter();
filter.PersonType.Code.SetField(item);
}
else if (item.Key == CustomerFilterField.PersonTypeName)
{
filter.PersonType ??= new CodeNameFilter();
filter.PersonType.Name ??= new StringFilter();
filter.PersonType.Name.SetField(item);
}
else if (item.Key == CustomerFilterField.IdentityTypeCode)
{
filter.IdentityType ??= new CodeNameFilter();
filter.IdentityType.Code ??= new IntFilter();
filter.IdentityType.Code.SetField(item);
}
else if (item.Key == CustomerFilterField.IdentityTypeName)
{
filter.IdentityType ??= new CodeNameFilter();
filter.IdentityType.Name ??= new StringFilter();
filter.IdentityType.Name.SetField(item);
}
else if (item.Key == CustomerFilterField.Identity)
{
filter.Identity ??= new StringFilter();
filter.Identity.SetField(item);
}
else if (item.Key == CustomerFilterField.BirthDate)
{
filter.BirthDate ??= new DateTimeFilter();
filter.BirthDate.SetField(item);
}
else if (item.Key == CustomerFilterField.StatusCode)
{
filter.Status ??= new StatusFieldFilter();
filter.Status.Code ??= new IntFilter();
filter.Status.Code.SetField(item);
}
else if (item.Key == CustomerFilterField.StatusName)
{
filter.Status ??= new StatusFieldFilter();
filter.Status.Name ??= new StringFilter();
filter.Status.Name.SetField(item);
}
else if (item.Key == CustomerFilterField.StatusDate)
{
filter.Status ??= new StatusFieldFilter();
filter.Status.Date ??= new DateTimeFilter();
filter.Status.Date.SetField(item);
}
else if (item.Key == CustomerFilterField.StatusColor)
{
filter.Status ??= new StatusFieldFilter();
filter.Status.Color ??= new StringFilter();
filter.Status.Color.SetField(item);
}
else if (item.Key == CustomerFilterField.StatusNote)
{
filter.Status ??= new StatusFieldFilter();
filter.Status.Note ??= new StringFilter();
filter.Status.Note.SetField(item);
}
else if (item.Key == CustomerFilterField.Enabled)
{
filter.Enabled ??= new BooleanFilter();
filter.Enabled.SetField(item);
}
//!Validar
//else if (item.Key == CustomerFilterField.Addresses)
//{
//filter.Addresses ??= new XptoFilter();
//filter.Addresses ??= new XptoFilter();
//filter.Addresses.SetField(item);
//}
//!Validar
//else if (item.Key == CustomerFilterField.Phones)
//{
//filter.Phones ??= new XptoFilter();
//filter.Phones ??= new XptoFilter();
//filter.Phones.SetField(item);
//}
//!Validar
//else if (item.Key == CustomerFilterField.Emails)
//{
//filter.Emails ??= new XptoFilter();
//filter.Emails ??= new XptoFilter();
//filter.Emails.SetField(item);
//}
//!Validar
//else if (item.Key == CustomerFilterField.Documents)
//{
//filter.Documents ??= new XptoFilter();
//filter.Documents ??= new XptoFilter();
//filter.Documents.SetField(item);
//}
//!Validar
//else if (item.Key == CustomerFilterField.BankAccounts)
//{
//filter.BankAccounts ??= new XptoFilter();
//filter.BankAccounts ??= new XptoFilter();
//filter.BankAccounts.SetField(item);
//}
//!Validar
//else if (item.Key == CustomerFilterField.Fields)
//{
//filter.Fields ??= new XptoFilter();
//filter.Fields ??= new XptoFilter();
//filter.Fields.SetField(item);
//}
//!Validar
//else if (item.Key == CustomerFilterField.Tags)
//{
//filter.Tags ??= new XptoFilter();
//filter.Tags ??= new XptoFilter();
//filter.Tags.SetField(item);
//}
else if (item.Key == CustomerFilterField.TagCodes)
{
filter.TagCodes ??= new IntListFilter();
filter.TagCodes.SetField(item);
}
//!Validar
//else if (item.Key == CustomerFilterField.Alerts)
//{
//filter.Alerts ??= new XptoFilter();
//filter.Alerts ??= new XptoFilter();
//filter.Alerts.SetField(item);
//}
//!Validar
//else if (item.Key == CustomerFilterField.Relationships)
//{
//filter.Relationships ??= new XptoFilter();
//filter.Relationships ??= new XptoFilter();
//filter.Relationships.SetField(item);
//}
else if (item.Key == CustomerFilterField.ParentId)
{
filter.Parent ??= new IdCodeNameFilter();
filter.Parent.Id ??= new GuidFilter();
filter.Parent.Id.SetField(item);
}
else if (item.Key == CustomerFilterField.ParentCode)
{
filter.Parent ??= new IdCodeNameFilter();
filter.Parent.Code ??= new IntFilter();
filter.Parent.Code.SetField(item);
}
else if (item.Key == CustomerFilterField.ParentName)
{
filter.Parent ??= new IdCodeNameFilter();
filter.Parent.Name ??= new StringFilter();
filter.Parent.Name.SetField(item);
}
//!Validar
//else if (item.Key == CustomerFilterField.TimeZone)
//{
//filter.TimeZone ??= new XptoFilter();
//filter.TimeZone ??= new XptoFilter();
//filter.TimeZone.SetField(item);
//}
else if (item.Key == CustomerFilterField.Avatar)
{
filter.Avatar ??= new StringFilter();
filter.Avatar.SetField(item);
}
else if (item.Key == CustomerFilterField.Image)
{
filter.Image ??= new StringFilter();
filter.Image.SetField(item);
}
else if (item.Key == CustomerFilterField.Color)
{
filter.Color ??= new StringFilter();
filter.Color.SetField(item);
}
else if (item.Key == CustomerFilterField.ReferenceCode)
{
filter.ReferenceCode ??= new StringFilter();
filter.ReferenceCode.SetField(item);
}
else if (item.Key == CustomerFilterField.ExternalCode)
{
filter.ExternalCode ??= new StringFilter();
filter.ExternalCode.SetField(item);
}
else if (item.Key == CustomerFilterField.Ids)
{
filter.Ids ??= new GuidListFilter();
filter.Ids.SetField(item);
}
else if (item.Key == CustomerFilterField.Note)
{
filter.Note ??= new StringFilter();
filter.Note.SetField(item);
}
else if (item.Key == CustomerFilterField.DealerId)
{
filter.Dealer ??= new IdCodeNameFilter();
filter.Dealer.Id ??= new GuidFilter();
filter.Dealer.Id.SetField(item);
}
else if (item.Key == CustomerFilterField.DealerCode)
{
filter.Dealer ??= new IdCodeNameFilter();
filter.Dealer.Code ??= new IntFilter();
filter.Dealer.Code.SetField(item);
}
else if (item.Key == CustomerFilterField.DealerName)
{
filter.Dealer ??= new IdCodeNameFilter();
filter.Dealer.Name ??= new StringFilter();
filter.Dealer.Name.SetField(item);
}
else if (item.Key == CustomerFilterField.CompanyId)
{
filter.Company ??= new IdCodeNameFilter();
filter.Company.Id ??= new GuidFilter();
filter.Company.Id.SetField(item);
}
else if (item.Key == CustomerFilterField.CompanyCode)
{
filter.Company ??= new IdCodeNameFilter();
filter.Company.Code ??= new IntFilter();
filter.Company.Code.SetField(item);
}
else if (item.Key == CustomerFilterField.CompanyName)
{
filter.Company ??= new IdCodeNameFilter();
filter.Company.Name ??= new StringFilter();
filter.Company.Name.SetField(item);
}
else if (item.Key == CustomerFilterField.AccountId)
{
filter.Account ??= new IdCodeNameFilter();
filter.Account.Id ??= new GuidFilter();
filter.Account.Id.SetField(item);
}
else if (item.Key == CustomerFilterField.AccountCode)
{
filter.Account ??= new IdCodeNameFilter();
filter.Account.Code ??= new IntFilter();
filter.Account.Code.SetField(item);
}
else if (item.Key == CustomerFilterField.AccountName)
{
filter.Account ??= new IdCodeNameFilter();
filter.Account.Name ??= new StringFilter();
filter.Account.Name.SetField(item);
}
else if (item.Key == CustomerFilterField.PartnerId)
{
filter.Partner ??= new IdCodeNameFilter();
filter.Partner.Id ??= new GuidFilter();
filter.Partner.Id.SetField(item);
}
else if (item.Key == CustomerFilterField.PartnerCode)
{
filter.Partner ??= new IdCodeNameFilter();
filter.Partner.Code ??= new IntFilter();
filter.Partner.Code.SetField(item);
}
else if (item.Key == CustomerFilterField.PartnerName)
{
filter.Partner ??= new IdCodeNameFilter();
filter.Partner.Name ??= new StringFilter();
filter.Partner.Name.SetField(item);
}
else if (item.Key == CustomerFilterField.StoreId)
{
filter.Store ??= new IdCodeNameFilter();
filter.Store.Id ??= new GuidFilter();
filter.Store.Id.SetField(item);
}
else if (item.Key == CustomerFilterField.StoreCode)
{
filter.Store ??= new IdCodeNameFilter();
filter.Store.Code ??= new IntFilter();
filter.Store.Code.SetField(item);
}
else if (item.Key == CustomerFilterField.StoreName)
{
filter.Store ??= new IdCodeNameFilter();
filter.Store.Name ??= new StringFilter();
filter.Store.Name.SetField(item);
}
else if (item.Key == CustomerFilterField.BrokerId)
{
filter.Broker ??= new IdCodeNameFilter();
filter.Broker.Id ??= new GuidFilter();
filter.Broker.Id.SetField(item);
}
else if (item.Key == CustomerFilterField.BrokerCode)
{
filter.Broker ??= new IdCodeNameFilter();
filter.Broker.Code ??= new IntFilter();
filter.Broker.Code.SetField(item);
}
else if (item.Key == CustomerFilterField.BrokerName)
{
filter.Broker ??= new IdCodeNameFilter();
filter.Broker.Name ??= new StringFilter();
filter.Broker.Name.SetField(item);
}
else if (item.Key == CustomerFilterField.CreationDate)
{
filter.Log ??= new RecordLogFilter();
filter.Log.CreationDate ??= new DateTimeFilter();
filter.Log.CreationDate.SetField(item);
}
else if (item.Key == CustomerFilterField.CreationUserId)
{
filter.Log ??= new RecordLogFilter();
filter.Log.CreationUser ??= new IdCodeNameFilter();
filter.Log.CreationUser.Id ??= new GuidFilter();
filter.Log.CreationUser.Id.SetField(item);
}
else if (item.Key == CustomerFilterField.CreationUserCode)
{
filter.Log ??= new RecordLogFilter();
filter.Log.CreationUser ??= new IdCodeNameFilter();
filter.Log.CreationUser.Code ??= new IntFilter();
filter.Log.CreationUser.Code.SetField(item);
}
else if (item.Key == CustomerFilterField.CreationUserName)
{
filter.Log ??= new RecordLogFilter();
filter.Log.CreationUser ??= new IdCodeNameFilter();
filter.Log.CreationUser.Name ??= new StringFilter();
filter.Log.CreationUser.Name.SetField(item);
}
else if (item.Key == CustomerFilterField.ChangeDate)
{
filter.Log ??= new RecordLogFilter();
filter.Log.ChangeDate ??= new DateTimeFilter();
filter.Log.ChangeDate.SetField(item);
}
else if (item.Key == CustomerFilterField.ChangeUserId)
{
filter.Log ??= new RecordLogFilter();
filter.Log.ChangeUser ??= new IdCodeNameFilter();
filter.Log.ChangeUser.Id ??= new GuidFilter();
filter.Log.ChangeUser.Id.SetField(item);
}
else if (item.Key == CustomerFilterField.ChangeUserCode)
{
filter.Log ??= new RecordLogFilter();
filter.Log.ChangeUser ??= new IdCodeNameFilter();
filter.Log.ChangeUser.Code ??= new IntFilter();
filter.Log.ChangeUser.Code.SetField(item);
}
else if (item.Key == CustomerFilterField.ChangeUserName)
{
filter.Log ??= new RecordLogFilter();
filter.Log.ChangeUser ??= new IdCodeNameFilter();
filter.Log.ChangeUser.Name ??= new StringFilter();
filter.Log.ChangeUser.Name.SetField(item);
}
else if (item.Key == CustomerFilterField.ExclusionDate)
{
filter.Log ??= new RecordLogFilter();
filter.Log.ExclusionDate ??= new DateTimeFilter();
filter.Log.ExclusionDate.SetField(item);
}
else if (item.Key == CustomerFilterField.ExclusionUserId)
{
filter.Log ??= new RecordLogFilter();
filter.Log.ExclusionUser ??= new IdCodeNameFilter();
filter.Log.ExclusionUser.Id ??= new GuidFilter();
filter.Log.ExclusionUser.Id.SetField(item);
}
else if (item.Key == CustomerFilterField.ExclusionUserCode)
{
filter.Log ??= new RecordLogFilter();
filter.Log.ExclusionUser ??= new IdCodeNameFilter();
filter.Log.ExclusionUser.Code ??= new IntFilter();
filter.Log.ExclusionUser.Code.SetField(item);
}
else if (item.Key == CustomerFilterField.ExclusionUserName)
{
filter.Log ??= new RecordLogFilter();
filter.Log.ExclusionUser ??= new IdCodeNameFilter();
filter.Log.ExclusionUser.Name ??= new StringFilter();
filter.Log.ExclusionUser.Name.SetField(item);
}
else if (item.Key == CustomerFilterField.VersionId)
{
filter.Log ??= new RecordLogFilter();
filter.Log.VersionId ??= new GuidFilter(); 
filter.Log.VersionId.SetField(item);
}

else if (item.Key == CustomerFilterField.PreviousId)
{
filter.Log ??= new RecordLogFilter();
filter.Log.PreviousId ??= new GuidFilter();
filter.Log.PreviousId.SetField(item);
}
else if (item.Key == CustomerFilterField.VersionDate)
{
filter.Log ??= new RecordLogFilter();
filter.Log.VersionDate ??= new DateTimeFilter();
filter.Log.VersionDate.SetField(item);
}
}
}
}
}
