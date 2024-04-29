// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29

using Ajinsoft.Credentials3;
using Ajinsoft.Features;
using Ajinsoft.Results;
using Ajinsoft.Tools.Hierarchies;
using Ajinsoft.Tools.Hierarchies.Items;
using Ajinsoft.Tools.Hierarchies.Levels;
using Ajinsoft.Tools.Customers;
using Ajinsoft.Tools.Users;
using Ajinsoft.Tools.Users.Rules;
using Ajinsoft.Tools.Users.Supports;

namespace Ajinsoft.Tools.Services.Customers
{
public class CustomerLevelService : ResultService, ICustomerLevelService
{
private readonly ICustomerRepository customer3Repository;
private readonly IUserRuleRepository ruleRepository;
private readonly IUserRepository userRepository;
private readonly IHierarchyRepository hierarchyRepository;
private readonly IHierarchyLevelItemRepository hierarchyItemRepository;
private readonly ICredentialService credentialService;


public CustomerLevelService(
ICustomerRepository customer3Repository,
IUserRuleRepository ruleRepository,
IUserRepository userRepository,
IHierarchyRepository hierarchyRepository,
IHierarchyLevelItemRepository hierarchyItemRepository,
ICredentialService credentialService)
{
this.customer3Repository = customer3Repository;
this.ruleRepository = ruleRepository;
this.userRepository = userRepository;
this.hierarchyRepository = hierarchyRepository;
this.hierarchyItemRepository = hierarchyItemRepository;
this.credentialService = credentialService;
}

public async Task<CustomerLevelFilter> GetFilterAsync()
{
var filter = new CustomerLevelFilter();

var credential = this.credentialService.Credential;

if (credential.AccessType.Equals(UserAccessType.Full))
{
filter.All = true;
return filter;
}

var levels = await this.ruleRepository.FindLevelsAsync(
credential.Profile,
new List<int>
{
Feature.App,
Feature.Customer
});

if (levels.Count == 0)
{
filter.All = true;
return filter;
}

foreach (var level in levels)
{
if (level.Code == CustomerRules.ViewOwnAccount)
{
filter.AccountIds.Add(credential.Account);
continue;
}

if (level.Code == CustomerRules.ViewSelectedAccounts)
{
if (level.Codes is null || level.Codes.Count == 0)
continue;

filter.AccountIds.AddRange(level.Ids);
continue;
}

if (level.Code == CustomerRules.ViewOwnStore)
{
filter.StoreIds.Add(credential.Store);
continue;
}

if (level.Code == CustomerRules.ViewSelectedStores)
{
if (level.Codes is null || level.Codes.Count == 0)
continue;

filter.StoreIds.AddRange(level.Ids);
continue;
}

if (level.Code == CustomerRules.ViewStoreGroups)
{
//filter.StoreIds = new List<int>();

//if (level.Items is null || level.Items?.Count == 0)
//    continue;

//IList<int> groupCodes = level.Items.Select(item => item.Code).ToList();

//var codes = await this.groupItemRepository.ListCodesAsync(credential.CompanyCode, Feature.Store, groupCodes);

//if (codes.Count == 0)
//    continue;

//foreach (var code in codes)
//{
//    filter.StoreCodes.Add(code);
//}
}

if (level.Code == CustomerRules.ViewOwnStoreGroup)
{
//var groupIds =
//    await this.userRepository.GetGroupIdsAsync(credential.CompanyCode, credential.UserId);

//if (groupIds.Count == 0)
//{
//    filter.None = true;
//    return filter;
//}


//filter.StoreCodes = new List<int>();

//var codes = await this.groupItemRepository.ListCodesAsync(credential.CompanyCode, Feature.Store, groupIds);

//if (codes.Count == 0)
//{
//    filter.None = true;
//    return filter;
//}

//foreach (var code in codes)
//{
//    filter.StoreCodes.Add(code);
//}

continue;
}


if (level.Code == CustomerRules.ViewOwnBroker)
{
filter.BrokerIds.Add(credential.Broker);
continue;
}

//if (level.Code == CustomerRules.ViewOwnBrokersAndBelow)
//{
//    filter.BrokerCodes = new List<int>
//    {
//        credential.BrokerCode
//    };

//    var brokerCodes =
//        await this.brokerRepository.ListChildrenCodesAsync(credential.CompanyCode,
//            credential.BrokerCode);

//    foreach (var brokerCode in brokerCodes)
//    {
//        filter.BrokerCodes.Add(brokerCode);
//    }
//}

if (level.Code == CustomerRules.ViewSelectedBrokers)
{
if (level.Codes is null || level.Codes.Count == 0)
continue;

filter.BrokerIds.AddRange(level.Ids);
continue;
}

if (level.Code == CustomerRules.ViewBrokerGroups)
{
//filter.BrokerCodes = new List<int>();

//if (level.Items is null || level.Items?.Count == 0)
//    continue;

//IList<int> groupCodes = level.Items.Select(item => item.Code).ToList();

//var codes = await this.groupItemRepository.ListCodesAsync(credential.CompanyCode, Feature.Broker, groupCodes);

//if (codes.Count == 0)
//    continue;

//foreach (var code in codes)
//{
//    filter.BrokerCodes.Add(code);
//}

continue;
}

if (level.Code == CustomerRules.ViewOwnBrokerGroup)
{
//var groupIds =
//    await this.userRepository.GetGroupIdsAsync(credential.CompanyCode, credential.UserId);

//if (groupIds.Count == 0)
//{
//    filter.None = true;
//    return filter;
//}

//filter.BrokerCodes = new List<int>();

//var codes = await this.groupItemRepository.ListCodesAsync(credential.CompanyCode, Feature.Broker, groupIds);

//if (codes.Count == 0)
//{
//    filter.None = true;
//    return filter;
//}

//foreach (var code in codes)
//{
//    filter.BrokerCodes.Add(code);
//}

continue;
}

if (level.Code == CustomerRules.ViewWithStatus)
{
//filter.StatusCodes = new List<int>();

//if (level.Items is null || level.Items?.Count == 0)
//    continue;

//foreach (var item in level.Items)
//{
//    filter.StatusCodes.Add(item.Code);
//}

//if (level.Code == CustomerRules.ViewStatusEdit)
//{
//    if (level.Items is null || level.Items?.Count == 0)
//        continue;

//    foreach (var item in level.Items)
//    {
//        filter.StatusCodes.Add(item.Code);
//    }
//}
}

if (level.Code == CustomerRules.ViewAccordingToHierarchy)
{
var user = await this.userRepository.GetAsync(credential.User.Id);

if (user is null)
{
filter.None = true;
return filter;
}

var userHierarchies = user.Hierarchies.Select(x => x).Where(x => x.Feature.Code == Feature.Customer.Code).ToList();
var levelIds = new List<Guid>();
var hierarchyIds = new List<Guid>();
foreach (var hierarchy in userHierarchies)
{
if (hierarchy.Id != Guid.Empty)
hierarchyIds.Add(hierarchy.Id);

if (hierarchy.Level is not null && hierarchy.Level.Id != Guid.Empty)
levelIds.Add(hierarchy.Level.Id);
}


if (hierarchyIds.Count == 0 || levelIds.Count == 0)
{
filter.None = true;
return filter;
}

var hierarchies = await this.hierarchyRepository.FindAsync(credential, hierarchyIds);

if (hierarchies.Count == 0)
{
filter.None = true;
return filter;
}


var items = new List<HierarchyLevel>();

foreach (var hierarchy in hierarchies)
{
hierarchy.Levels ??= new List<HierarchyLevel>();

foreach (var item in hierarchy.Levels)
{
foreach (var levelId in levelIds)
{
if (item.Id == levelId)
{
items.Add(item);
break;
}

var _level = GetLevel(item.Levels, levelId);
if (_level != null)
{
items.Add(item);
break;
}

}
}
}


if (items.Count == 0)
{
filter.None = true;
return filter;
}


levelIds = GetLevelIds(items);

filter.Ids = await this.hierarchyItemRepository.ListParentIdsByLevelsAsync(credential, levelIds);

if (filter.Ids.Count == 0)
{
filter.None = true;
return filter;
}

}
}

return filter;
}

private HierarchyLevel GetLevel(IList<HierarchyLevel> levels, Guid levelId)
{
levels ??= new List<HierarchyLevel>();

foreach (var item in levels)
{

if (item.Id == levelId)
return item;

item.Levels ??= new List<HierarchyLevel>();
if (item.Levels.Count == 0)
continue;

var level = GetLevel(item.Levels, levelId);

if (level is not null)
return level;
}

return null;
}

private List<Guid> GetLevelIds(IList<HierarchyLevel> levels)
{
var levelIds = new List<Guid>();

foreach (var item in levels)
{
if (item.Id != Guid.Empty)
levelIds.Add(item.Id);

if (!(item.Levels?.Count > 0))
continue;

var ids = GetLevelIds(item.Levels);
levelIds.AddRange(ids);
}

return levelIds;
}

public async Task<bool> HasAccessAsync(Guid id)
{
var level = await this.GetFilterAsync();

if (level is null || level.None)
return false;

return await this.customer3Repository.ExistsAsync(id, level);
}
}
}
