// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29


using Ajinsoft.Data.Mongo;
using Ajinsoft.Registers.Records;
using Ajinsoft.Tools.Customers;
using Ajinsoft.Tools.Shared.Entities.Aggregations;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ajinsoft.Tools.Repositories.Customers
{
public class CustomerSearchRepository : CustomerFilterRepository, ICustomerSearchRepository
{
private readonly IConnectionProvider connectionProvider;
private readonly string collectionName;

public CustomerSearchRepository(
IConnectionProvider connectionProvider,
string? collectionName = null)
{
this.connectionProvider = connectionProvider;
this.collectionName = CustomerRepositorySetting.CollectionName;

if (!string.IsNullOrWhiteSpace(collectionName))
this.collectionName = collectionName;
}

public async Task<SearchResult<CustomerSearchResult>> FindAsync(Credential credential, CustomerLevelFilter level, CustomerFilter filter, DataLevel dataLevel = DataLevel.Company)
{
var result = new SearchResult<CustomerSearchResult>
(
items: new List<CustomerSearchResult>(),
count: filter.Count ?? 0,
offset: filter.Offset ?? 0,
limit: filter.Limit ?? 0
);

var _filter =
Builders<Customer>.Filter.Eq(f => f.RecordStatus, RecordStatus.Active) &
Builders<Customer>.Filter.Eq(f => f.Company.Code, credential.Company.Code);

if (dataLevel == DataLevel.All)
_filter = Builders<Customer>.Filter.Eq(f => f.RecordStatus, RecordStatus.Active);

_filter &= this.GetLevel(level) &
this.GetFilter(credential, filter);

result.Items = await this.ListAsync(credential, _filter, filter?.Offset ?? 0, filter?.Limit ?? 0);
if (filter.Count is null)
result.Count = await this.CountAsync(_filter);

return result;
}

public async Task<SearchResult<BasicResult>> FindBasicAsync(Credential credential, CustomerLevelFilter level, CustomerFilter filter, DataLevel dataLevel = DataLevel.Company)
{
var result = new SearchResult<BasicResult>
(
items: new List<BasicResult>(),
count: filter.Count ?? 0,
offset: filter.Offset ?? 0,
limit: filter.Limit ?? 100
);

var _filter =
Builders<Customer>.Filter.Eq(f => f.RecordStatus, RecordStatus.Active) &
Builders<Customer>.Filter.Eq(f => f.Company.Code, credential.Company.Code);

if (dataLevel == DataLevel.All)
_filter = Builders<Customer>.Filter.Eq(f => f.RecordStatus, RecordStatus.Active);

_filter &= this.GetLevel(level) &
this.GetFilter(credential, filter);

result.Items = await this.ListBasicAsync(_filter, filter?.Offset ?? 0, filter?.Limit ?? 0);
if (filter.Count is null)
result.Count = await this.CountAsync(_filter);

return result;
}

public async Task<IList<BasicResult>> ListBasicAsync(FilterDefinition<Customer> filter, int offset, int limit)
{
var l = new List<BasicResult>();

var db = await this.connectionProvider.CreateConnectionAsync();
var collection = db.GetCollection<Customer>(this.collectionName);

var options = new FindOptions<Customer>
{
Projection = Builders<Customer>.Projection
.Include(p => p.Id)
.Include(p => p.Code)
.Include(p => p.Name)
.Include(p => p.Nickname)
.Include(p => p.Description)
.Include(p => p.Avatar)
.Include(p => p.Image)
.Include(p => p.Color)
.Include(p => p.ReferenceCode)
.Include(p => p.Note),
Skip = offset,
Limit = limit,
Sort = Builders<Customer>.Sort.Ascending(x => x.Name)
};

using var cursor = await collection.FindAsync(filter, options);
while (await cursor.MoveNextAsync())
{
l.AddRange(cursor.Current.Select(item => new BasicResult
{
Id = item.Id,
Code = item.Code,
Name = item.Name,
Nickname = item.Nickname,
Description = item.Description,
Avatar = item.Avatar,
Image = item.Image,
Color = item.Color,
ReferenceCode = item.ReferenceCode,
Note = item.Note
}));
}

return l;
}

public async Task<IList<CustomerSearchResult>> ListAsync(Credential credential, CustomerLevelFilter level, CustomerFilter filter, DataLevel dataLevel = DataLevel.Company)
{
var _filter =
Builders<Customer>.Filter.Eq(f => f.RecordStatus, RecordStatus.Active) &
Builders<Customer>.Filter.Eq(f => f.Company.Code, credential.Company.Code);

if (dataLevel == DataLevel.All)
_filter = Builders<Customer>.Filter.Eq(f => f.RecordStatus, RecordStatus.Active);

_filter &= this.GetLevel(level) &
this.GetFilter(credential, filter);

return await this.ListAsync(credential, _filter, filter?.Offset ?? 0, filter?.Limit ?? 0);
}

public async Task<IList<CustomerSearchResult>> ListAsync(Credential credential, FilterDefinition<Customer> filter, int offset, int limit)
{
var l = new List<CustomerSearchResult>();

var db = await this.connectionProvider.CreateConnectionAsync();
var collection = db.GetCollection<Customer>(this.collectionName);

var options = new FindOptions<Customer>
{
Projection = Builders<Customer>.Projection
.Include(p => p.Id)
.Include(p => p.Code)
.Include(p => p.Feature)
.Include(p => p.Type)
.Include(p => p.Name)
.Include(p => p.Nickname)
.Include(p => p.Description)
.Include(p => p.PersonType)
.Include(p => p.IdentityType)
.Include(p => p.Identity)
.Include(p => p.BirthDate)
.Include(p => p.Status)
.Include(p => p.Enabled)
.Include(p => p.Parent)
.Include(p => p.TimeZone)
.Include(p => p.Avatar)
.Include(p => p.Image)
.Include(p => p.Color)
.Include(p => p.ReferenceCode)
.Include(p => p.ExternalCode)
.Include(p => p.Note)
.Include(p => p.Dealer)
.Include(p => p.Company)
.Include(p => p.Account)
.Include(p => p.Partner)
.Include(p => p.Store)
.Include(p => p.Broker)
.Include(p => p.Log)
,
Skip = offset,
Limit = limit,
Sort = Builders<Customer>.Sort.Descending(x => x.Log.CreationDate)
};

using var cursor = await collection.FindAsync(filter, options);
while (await cursor.MoveNextAsync())
{
l.AddRange(cursor.Current.Select(item => new CustomerSearchResult
{
Id = item.Id,
Code = item.Code,
Feature = item.Feature,
Type = item.Type,
Name = item.Name,
Nickname = item.Nickname,
Description = item.Description,
PersonType = item.PersonType,
IdentityType = item.IdentityType,
Identity = item.Identity,
BirthDate = DateFunctions3.GetStringDateTime(item.BirthDate, credential.TimeZoneInfo),
Status = item.Status,
Enabled = item.Enabled,
Parent = item.Parent,
TimeZone = item.TimeZone,
Avatar = item.Avatar,
Image = item.Image,
Color = item.Color,
ReferenceCode = item.ReferenceCode,
ExternalCode = item.ExternalCode,
Note = item.Note,
Dealer = item.Dealer,
Company = item.Company,
Account = item.Account,
Partner = item.Partner,
Store = item.Store,
Broker = item.Broker,
Log = new RecordLogResult(item.Log, credential.TimeZoneInfo),
}));
}

return l;
}

public async Task<IList<IdCodeName>> ListSimpleAsync(Credential credential, CustomerLevelFilter level, CustomerFilter filter, DataLevel dataLevel = DataLevel.Company)
{
var _filter =
Builders<Customer>.Filter.Eq(f => f.RecordStatus, RecordStatus.Active) &
Builders<Customer>.Filter.Eq(f => f.Company.Code, credential.Company.Code);

if (dataLevel == DataLevel.All)
_filter = Builders<Customer>.Filter.Eq(f => f.RecordStatus, RecordStatus.Active);

_filter &= this.GetLevel(level) &
this.GetFilter(credential, filter);

var l = new List<IdCodeName>();

var db = await this.connectionProvider.CreateConnectionAsync();
var collection = db.GetCollection<Customer>(this.collectionName);

var options = new FindOptions<Customer>
{
Projection = Builders<Customer>.Projection
.Include(p => p.Id)
.Include(p => p.Code)
.Include(p => p.Name),
Skip = filter.Offset,
Limit = filter.Limit,
Sort = Builders<Customer>.Sort.Descending(s => s.Log.CreationDate)
};

using var cursor = await collection.FindAsync(_filter, options);
while (await cursor.MoveNextAsync())
{
l.AddRange(cursor.Current.Select(item => new IdCodeName
{
Id = item.Id,
Code = item.Code,
Name = item.Name
}));
}

return l;
}

public async Task<long> CountAsync(Credential credential, CustomerLevelFilter level, CustomerFilter filter, DataLevel dataLevel = DataLevel.Company)
{
var _filter =
Builders<Customer>.Filter.Eq(f => f.RecordStatus, RecordStatus.Active) &
Builders<Customer>.Filter.Eq(f => f.Company.Code, credential.Company.Code);

if (dataLevel == DataLevel.All)
_filter = Builders<Customer>.Filter.Eq(f => f.RecordStatus, RecordStatus.Active);

_filter &= this.GetLevel(level) &
this.GetFilter(credential, filter);

return await this.CountAsync(_filter);
}

public async Task<long> CountAsync(FilterDefinition<Customer> filter)
{
var db = await this.connectionProvider.CreateConnectionAsync();
var collection = db.GetCollection<Customer>(this.collectionName);
return await collection.CountDocumentsAsync(filter);
}

public async Task<IList<AggregationItem>> AggregateByStatusAsync(Credential credential, CustomerLevelFilter level, CustomerFilter filter, DataLevel dataLevel = DataLevel.Company)
{
filter ??= new CustomerFilter();

var _filter =
Builders<Customer>.Filter.Eq(f => f.RecordStatus, RecordStatus.Active) &
Builders<Customer>.Filter.Eq(f => f.Company.Code, credential.Company.Code);

if (dataLevel == DataLevel.All)
_filter = Builders<Customer>.Filter.Eq(f => f.RecordStatus, RecordStatus.Active);

_filter &= this.GetLevel(level) &
this.GetFilter(credential, filter);

return await this.AggregationByStatusAsync(credential, _filter);
}

public async Task<IList<AggregationItem>> AggregationByStatusAsync(Credential credential, FilterDefinition<Customer> filter)
{
var l = new List<AggregationItem>();

var db = await this.connectionProvider.CreateConnectionAsync();
var collection = db.GetCollection<Customer>(this.collectionName);

var result = collection.Aggregate()
.Match(filter)
.Group(
g => new { g.Status.Code, g.Status.Name },
x => new
{
Status = x.Key,
StatusColor = x.Max(f => f.Status.Color),
Value = x.Sum(f => f.Value),
NetValue = x.Sum(f => f.NetValue),
Count = x.Sum(f => 1)
})
.SortByDescending(s => s.Count)
.ToList();

if (result is null)
return l;

foreach (var item in result)
{
l.Add(new AggregationItem
{
Code = item.Status.Code,
Label = item.Status.Name,
Color = item.StatusColor,
Value = item.Value,
NetValue = item.NetValue,
Count = item.Count
});
}

return l;
}
}
}
