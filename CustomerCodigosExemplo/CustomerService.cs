// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29

namespace Ajinsoft.Tools.Services.v3.Customers
{
public class CustomerService : ICustomerService
{
private readonly ICustomerRepository customerRepository;
private readonly ICustomerLevelService levelService;
private readonly IAccountRepository accountRepository;
private readonly IPartnerRepository partnerRepository;
private readonly IStoreRepository storeRepository;
private readonly IBrokerRepository brokerRepository;
private readonly IStatusRepository statusRepository;
private readonly ICodeGenerator3Service codeGeneratorService;
private readonly ITrash3Repository trashRepository;
private readonly IAssertionService assertionService;
private readonly ILog3Service logService;
private readonly ICredentialService credentialService;
private readonly IResultService resultService;

public CustomerService(
ICustomerRepository customerRepository,
ICustomerLevelService levelService,
IAccountRepository accountRepository,
IPartnerRepository partnerRepository,
IStoreRepository storeRepository,
IBrokerRepository brokerRepository,
IStatusRepository statusRepository,
ICodeGenerator3Service codeGeneratorService,
ITrash3Repository trashRepository,
IAssertionService assertionService,
ILog3Service logService,
ICredentialService credentialService,
IResultService resultService
)
{
this.customerRepository = customerRepository;
this.codeGeneratorService = codeGeneratorService;
this.trashRepository = trashRepository;
this.assertionService = assertionService;
this.levelService = levelService;
this.accountRepository = accountRepository;
this.partnerRepository = partnerRepository;
this.storeRepository = storeRepository;
this.brokerRepository = brokerRepository;
this.statusRepository = statusRepository;
this.logService = logService;
this.credentialService = credentialService;
this.resultService = resultService;
}

public async Task<CustomerResult> CreateAsync(CustomerParams @params)
{
var credential = await this.credentialService.LoadAsync(CustomerRules.Create);
var logParams = new Log3Params(CustomerEventTypes.Creation);

try
{
if (await this.assertionService.HasErrors(credential, logParams))
return null;

if (!await this.assertionService.Assert(credential, Assert.NotNull(@params), FeatureMessages.InvalidParameter, logParams))
return null;

var model = await Customer.CreateAsync(
@params,
credential,
this.customerRepository,
this.accountRepository,
this.partnerRepository,
this.storeRepository,
this.brokerRepository,
this.codeGeneratorService,
this.resultService);

if (await this.assertionService.HasErrors(credential, logParams))
return null;

await this.customerRepository.InsertAsync(model);

await this.logService.CreateSuccessAsync(credential, 
logParams,
model,
new Log3Options
{
RecordId = model.Id,
Description = model.Name,
VersionId = model.Log.VersionId
});

return new CustomerResult(model, credential);

}
catch (Exception e)
{
await this.logService.CreateInternalErrorAsync(credential, logParams, e);
return null;
}
}

public async Task<CustomerResult> UpdateAsync(Guid id, CustomerParams @params)
{
var credential = await this.credentialService.LoadAsync(CustomerRules.Edit);
var logParams = new Log3Params(CustomerEventTypes.Update);

try
{
if (await this.assertionService.HasErrors(credential, logParams))
return null;

if (!await this.assertionService.Assert(credential, Assert.NotNull(@params), FeatureMessages.InvalidParameter, logParams))
return null;

var model = await this.customerRepository.GetAsync(credential, id);

if (!await this.assertionService.Assert(credential, Assert.NotNull(model), CustomerMessages.NotFound, logParams, new Log3Options { RecordId = id } ))
return null;

await model.UpdateAsync(
@params,
credential,
this.customerRepository,
this.accountRepository,
this.partnerRepository,
this.storeRepository,
this.brokerRepository,
this.resultService);

if (await this.assertionService.HasErrors(credential, logParams, new Log3Options { RecordId = id }))
return null;

await this.customerRepository.UpdateAsync(model);

await this.logService.CreateSuccessAsync(credential, 
logParams,
model,
new Log3Options
{
RecordId = model.Id,
Description = model.Name,
VersionId = model.Log.VersionId,
PreviousId = model.Log.PreviousId
});

return new CustomerResult(model, credential);
}
catch (Exception e)
{
await this.logService.CreateInternalErrorAsync(credential, logParams, e );
return null;
}
}

public async Task<CustomerResult> UpdateStatusAsync(Guid id, UpdateStatusParams @params)
{
var credential = await this.credentialService.LoadAsync( CustomerRules.Edit);
var logParams = new Log3Params(CustomerEventTypes.UpdateStatus);

try
{
if (await this.assertionService.HasErrors(credential,  logParams))
return null;

if (!await this.assertionService.Assert(credential, Assert.NotGuidNullOrEmpty(id), FeatureMessages.InvalidParameter, logParams, new Log3Options { RecordId = id } ))
return null;

if (!await this.assertionService.Assert(credential, Assert.NotNull(@params), FeatureMessages.InvalidParameter, logParams))
return null;

var model = await this.customerRepository.GetAsync(credential, id);

if (!await this.assertionService.Assert(credential, Assert.NotNull(model), CustomerMessages.NotFound, logParams, new Log3Options { RecordId = id }))
return null;

await model.UpdateStatusAsync(
@params,
credential,
this.statusRepository,
this.resultService);

//model.UpdateStatus(
//@params,
//credential,
//this.resultService);

if (await this.assertionService.HasErrors(credential, logParams, new Log3Options { RecordId = id }))
return null;

await this.customerRepository.UpdateAsync(model);

await this.logService.CreateSuccessAsync(credential, 
logParams,
model,
new Log3Options
{
RecordId = model.Id,
Description = model.Name,
VersionId = model.Log.VersionId,
PreviousId = model.Log.PreviousId
});

return new CustomerResult(model, credential);
}
catch (Exception e)
{
await this.logService.CreateInternalErrorAsync(credential, logParams, e, new Log3Options { RecordId = id });
return null;
}
}

public async Task<CountResult> DeleteAsync(IdListParams @params)
{
var credential = await this.credentialService.LoadAsync(CustomerRules.Delete);
var logParams = new Log3Params(CustomerEventTypes.Exclusion);

try
{
if (await this.assertionService.HasErrors(credential, logParams))
return null;

if (!await this.assertionService.Assert(credential, Assert.Greater(@params?.Ids?.Count ?? 0, 0), FeatureMessages.InvalidParameter, logParams))
return null;

if (@params?.Ids is null)
return null;

var result = new CountResult
{
Count = @params.Ids.Count
};

foreach (var id in @params.Ids)
{
var model = await this.customerRepository.GetAsync(credential, id);

if (!await this.assertionService.Assert(credential, Assert.NotNull(model), CustomerMessages.NotFound, logParams,  new Log3Options { RecordId = id }))
{
result.NotFound++;
continue;
}

if (model.RecordStatus == RecordStatus.Trash)
{
model.RecordDelete(credential);
await this.trashRepository.DeleteByRecordAsync(credential, model.Id);
}
else
{
var trash = model.ToTrash(credential);
await this.trashRepository.InsertAsync(trash);
}

await this.customerRepository.UpdateAsync(model);

await this.logService.CreateSuccessAsync(credential, 
logParams,
model,
new Log3Options
{
RecordId = model.Id,
Description = model.Name,
VersionId = model.Log.VersionId,
PreviousId = model.Log.PreviousId
});

result.Success++;
}

return result;
}
catch (Exception e)
{
await this.logService.CreateInternalErrorAsync(credential, logParams, e);
return null;
}
}

public async Task<CountResult> RestoreAsync(IdListParams @params)
{
var credential = await this.credentialService.LoadAsync(CustomerRules.Delete);
var logParams = new Log3Params(CustomerEventTypes.Restoration);

try
{
if (await this.assertionService.HasErrors(credential, logParams))
return null;

if (!await this.assertionService.Assert(credential, Assert.NotNull(@params?.Ids), FeatureMessages.InvalidParameter, logParams))
return null;

if (!await this.assertionService.Assert(credential, Assert.Greater(@params.Ids.Count, 0), FeatureMessages.InvalidParameter, logParams))
return null;

var result = new CountResult
{
Count = @params.Ids.Count,
};

foreach (var id in @params.Ids)
{
var model = await this.customerRepository.GetAnyAsync(id);

if (!await this.assertionService.Assert(credential, Assert.NotNull(model), CustomerMessages.NotFound, logParams, new Log3Options { RecordId = id }))
{
result.NotFound++;
continue;
}

model.RecordRestore(credential);
await this.customerRepository.UpdateAsync(model);
await this.trashRepository.DeleteByRecordAsync(credential, id);

await this.logService.CreateSuccessAsync(credential, 
logParams,
model,
new Log3Options
{
RecordId = model.Id,
Description = model.Name,
VersionId = model.Log.VersionId,
PreviousId = model.Log.PreviousId
});

result.Success++;
}

return result;

}
catch (Exception e)
{
await this.logService.CreateInternalErrorAsync(credential, logParams, e);
return null;
}
}

public async Task<CustomerResult> GetAsync(Guid id)
{
var credential = await this.credentialService.LoadAsync(CustomerRules.Access);
var logParams = new Log3Params(CustomerEventTypes.Selection);

try
{
if (await this.assertionService.HasErrors(credential, logParams))
return null;

if (!await this.assertionService.Assert(credential, Assert.NotGuidNullOrEmpty(id), FeatureMessages.InvalidParameter, logParams, new Log3Options { RecordId = id }))
return null;

var model = await this.customerRepository.GetAsync(credential, id);

if (!await this.assertionService.Assert(credential, Assert.NotNull(model), CustomerMessages.NotFound, logParams, new Log3Options { RecordId = id }))
return null;

await this.logService.CreateSuccessAsync(credential, 
logParams,
new Log3Options
{
RecordId = model.Id,
Description = model.Name,
VersionId = model.Log.VersionId,
PreviousId = model.Log.PreviousId
});

return new CustomerResult(model, credential);
}
catch (Exception e)
{
await this.logService.CreateInternalErrorAsync(credential, logParams, e, new Log3Options { RecordId = id });
return null;
}
}

public async Task<CustomerSupport> GetSupportAsync()
{
var credential = await this.credentialService.LoadAsync(CustomerRules.Access);
var logParams = new Log3Params(CustomerEventTypes.SupportLoading);

try
{
if (await this.assertionService.HasErrors(credential, logParams))
return null;

var result = new CustomerSupport();

await this.logService.CreateSuccessAsync(credential, logParams, new Log3Options());

return result;
}
catch (Exception e)
{
await this.logService.CreateInternalErrorAsync(credential, logParams, e);
return null;
}
}

public async Task<IEnumerable<FilterFieldType>> GetFilterFieldsAsync()
{
var credential = await this.credentialService.LoadAsync(CustomerRules.Access);
var logParams = new Log3Params(CustomerEventTypes.FilterFieldsLoading);

try
{
if (await this.assertionService.HasErrors(credential, logParams))
return null;

var result = ReflectionFunctions.ListStaticFields(typeof(CustomerFilterField)).Cast<FilterFieldType>().ToList().Where(x => x.Active);

await this.logService.CreateSuccessAsync(credential, logParams, new Log3Options());

return result;
}
catch (Exception e)
{
await this.logService.CreateInternalErrorAsync(credential, logParams, e, new Log3Options());
return null;
}
}

public async Task<CustomerSetting> GetSettingsAsync()
{
var credential = await this.credentialService.LoadAsync(CustomerRules.Access);
var logParams = new Log3Params(CustomerEventTypes.SettingLoading);

try
{
if (await this.assertionService.HasErrors(credential, logParams))
return null;

var result = new CustomerSetting();

await this.logService.CreateSuccessAsync(credential, logParams, new Log3Options());

return result;
}
catch (Exception e)
{
await this.logService.CreateInternalErrorAsync(credential, logParams, e);
return null;
}
}
}
}
