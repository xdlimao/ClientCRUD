// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29

using Ajinsoft.Commons.Data.Fields;
using Ajinsoft.Commons.Extensions;
using Ajinsoft.Credentials3;
using Ajinsoft.Features;
using Ajinsoft.Tools.v3.Dump;
using Ajinsoft.Tools.v3.TempExtensions;
using System.Collections.Generic;

namespace Ajinsoft.Tools.v3.Customers
{
public static class CustomerToTrash
{
public static Trash3 ToTrash(
this Customer @this,
Credential credential)
{
@this.RecordDelete(credential);

var model = new Trash3
{
Feature = Feature.Customer.ToCodeName(),
RecordId = @this.Id,
VersionId = @this.Log.VersionId,
Code = @this.Code,
Identity = null,
Description = @this.Name,
Status = @this.Status,
Type = @this.Type   ,
Icon = Feature.Customer.Icon,
Note = @this.Note,
Fields = new List<DataField>(),
User = credential.User
};

model.SetCompany(credential);
model.SetAccount(credential);
model.SetStore(credential);
model.SetBroker(credential);
model.RecordCreate(credential);
model.RecordCreate(credential);
return model;
}
}
}
