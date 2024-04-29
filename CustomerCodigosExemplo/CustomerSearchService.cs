// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29

namespace Ajinsoft.Tools.Services.v3.Customers
{
public class CustomerSearchService : ICustomerSearchService
{
private readonly ICustomerSearchRepository searchRepository;
private readonly ICustomerLevelService levelService;
private readonly IAssertionService assertionService;
private readonly ICredentialService credentialService;
private readonly ILog3Service logService;

public CustomerSearchService(
ICustomerSearchRepository searchRepository,
ICustomerLevelService levelService,
IAssertionService assertionService,
ICredentialService credentialService,
ILog3Service logService
)
{
this.searchRepository = searchRepository;
this.levelService = levelService;
this.assertionService = assertionService;
this.credentialService = credentialService;
this.logService = logService;
}

public async Task<SearchResult<CustomerSearchResult>> FindAsync(CustomerFilter filter)
{
var credential = await this.credentialService.LoadAsync(CustomerRules.Access);
var logParams = new Log3Params(CustomerEventTypes.Query);

try
{
if (await this.assertionService.HasErrors(credential, logParams))
return null;

var level = await this.levelService.GetFilterAsync();

filter ??= new CustomerFilter { Limit = 100 };

var result = new SearchResult<CustomerSearchResult>
(
items: new List<CustomerSearchResult>(),
count: 0,
offset: filter.Offset ?? 0,
limit: filter.Limit ?? 0
);

if (level is null || level.None)
return result;

result = await this.searchRepository.FindAsync(credential, level, filter);

await this.logService.CreateSuccessAsync(credential, 
logParams,
new Log3Options
{
Description = FeatureLabels.FindResult(result.Count, result.Page, result.Pages)
});

return result;
}
catch (Exception e)
{
await this.logService.CreateInternalErrorAsync(credential, logParams, e);
return null;
}
}

public async Task<SearchResult<BasicResult>> FindBasicAsync(CustomerFilter filter)
{
var credential = await this.credentialService.LoadAsync(CustomerRules.Access);
var logParams = new Log3Params(CustomerEventTypes.QueryBasic);

try
{
if (await this.assertionService.HasErrors(credential, logParams))
return null;

var level = await this.levelService.GetFilterAsync();

filter ??= new CustomerFilter { Limit = 100 };

var result = new SearchResult<BasicResult>
(
items: new List<BasicResult>(),
count: 0,
offset: filter.Offset ?? 0,
limit: filter.Limit ?? 100
);

if (level is null || level.None)
return result;

result = await this.searchRepository.FindBasicAsync(credential, level, filter);

await this.logService.CreateSuccessAsync(credential,
logParams,
new Log3Options
{
Description = FeatureLabels.FindResult(result.Count, result.Page, result.Pages)
});

return result;
}
catch (Exception e)
{
await this.logService.CreateInternalErrorAsync(credential, logParams, e);
return null;
}
}

public async Task<IList<CustomerSearchResult>> ListAsync(CustomerFilter filter)
{
var credential = await this.credentialService.LoadAsync(CustomerRules.Access);
var logParams = new Log3Params(CustomerEventTypes.Listing);

try
{
if (await this.assertionService.HasErrors(credential, logParams))
return null;

var level = await this.levelService.GetFilterAsync();

IList<CustomerSearchResult> result = new List<CustomerSearchResult>();

if (level is null || level.None)
return result;

result = await this.searchRepository.ListAsync(credential, level, filter);

await this.logService.CreateSuccessAsync(credential, 
logParams,
new Log3Options
{
Description = FeatureLabels.FindResult(result.Count, 1, 1)
});

return result;
}
catch (Exception e)
{
await this.logService.CreateInternalErrorAsync(credential, logParams, e);
return null;
}
}

public async Task<IList<IdCodeName>> ListSimpleAsync(CustomerFilter filter)
{
var credential = await this.credentialService.LoadAsync();
var logParams = new Log3Params(CustomerEventTypes.Listing);

try
{
if (await this.assertionService.HasErrors(credential, logParams))
return null;

var level = await this.levelService.GetFilterAsync();

IList<IdCodeName> result = new List<IdCodeName>();

if (level is null || level.None)
return result;

result = await this.searchRepository.ListSimpleAsync(credential, level, filter);

await this.logService.CreateSuccessAsync(credential, 
logParams,
new Log3Options
{
Description = FeatureLabels.FindResult(result.Count, 1, 1)
});

return result;
}
catch (Exception e)
{
await this.logService.CreateInternalErrorAsync(credential, logParams, e);
return null;
}
}

public async Task<Aggregation> AggregateByStatusAsync(CustomerFilter filter)
{
var credential = await this.credentialService.LoadAsync(CustomerRules.Access);
var logParams = new Log3Params(CustomerEventTypes.AggregationByStatus);

try
{
if (await this.assertionService.HasErrors(credential, logParams))
return null;

var level = await this.levelService.GetFilterAsync();
var result = new Aggregation();

if (level is null || level.None)
return result;

result.Items = await this.searchRepository.AggregateByStatusAsync(credential, level, filter);
result.Calc();

await this.logService.CreateSuccessAsync(credential, logParams, new Log3Options { Description = FeatureLabels.FindResult(result.TotalCount, 0, 0) });
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
