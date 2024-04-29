// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29

namespace Ajinsoft.Tools.v3.Customers
{
public static class CustomerUpdateStatus
{
public static async Task<Customer> UpdateStatusAsync(
this Customer @this,
UpdateStatusParams @params,
Credential credential,
IStatusRepository statusRepository,
IResultService resultService)
{
if (resultService.AddMessage(AssertMessage.NotNull(@params, FeatureMessages.InvalidParameter)))
return @this;

Status status = null;

var id = GuidFunctions.GetGuid(@params.Id);
if (id != Guid.Empty)
status = await statusRepository.GetAnyAsync(id);
else
{
var code = @params.Code ?? 0;
if (code > 0)
status = await statusRepository.GetAsync(credential, Feature.Customer, code);
}

if (resultService.AddMessage(AssertMessage.NotNull(status, FeatureMessages.InvalidStatus)))
return @this;

@this.Status = new StatusField(
status.Code,
status.Name,
DateFunctions.GetDate(@params?.Date) ?? DateTime.UtcNow,
status.Color,
@params?.Note
);

@this.RecordUpdate(credential);
return @this;
}
}
}
/*
using Ajinsoft.Commons.Fields.Status;
using Ajinsoft.Credentials;
using Ajinsoft.Features;
using Ajinsoft.Registers.Records;
using Ajinsoft.Results;
using Ajinsoft.Tools.v2.Shared.Params;
using Ajinsoft.Tools.v3.Customers.Supports;
using System;

namespace Ajinsoft.Tools.v3.Customers
{
public static class CustomerUpdateStatus
{
public static Customer UpdateStatus(
this Customer @this,
UpdateStatusParams @params,
Credential credential,
IResultService resultService)
{
var status = CustomerStatus.Get(@params?.Code ?? 0);

if (resultService.AddMessage(AssertMessage.NotNull(status, FeatureMessages.InvalidStatus)))
return @this;

@this.Status = new StatusField(
status.Code,
status.Name,
DateFunctions3.ToDateTime(@params?.Date) ?? DateTime.Now,
status.Color,
@params?.Note
);

@this.RecordUpdate(credential);
return @this;
}
}
}
*/
