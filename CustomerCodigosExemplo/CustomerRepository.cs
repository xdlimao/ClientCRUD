// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29



using Ajinsoft.Data.Mongo;
using Ajinsoft.Registers.Records;
using Ajinsoft.Tools.Customers;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ajinsoft.Tools.Repositories.Customers
{
public class CustomerRepository : CustomerFilterRepository, ICustomerRepository
{
private readonly IConnectionProvider connectionProvider;
private readonly string collectionName;

public CustomerRepository(
IConnectionProvider connectionProvider,
string? collectionName = null)
{
this.connectionProvider = connectionProvider;
this.collectionName = CustomerRepositorySetting.CollectionName;

if (!string.IsNullOrWhiteSpace(collectionName))
this.collectionName = collectionName;
}

public async Task<Customer> InsertAsync(Customer customer)
{
var db = await this.connectionProvider.CreateConnectionAsync();
var collection = db.GetCollection<Customer>(this.collectionName);

await collection.InsertOneAsync(customer);

return customer;
}

public async Task InsertManyAsync(IList<Customer> customers)
{
var db = await this.connectionProvider.CreateConnectionAsync();
var collection = db.GetCollection<Customer>(this.collectionName);

await collection.InsertManyAsync(customers);
}

public async Task<long> UpdateAsync(Customer customer)
{
var db = await this.connectionProvider.CreateConnectionAsync();
var collection = db.GetCollection<Customer>(this.collectionName);

var filter = Builders<Customer>.Filter.Eq(f => f.Id, customer.Id);

var result = await collection.ReplaceOneAsync(filter, customer);

return result.ModifiedCount;
}

public async Task<long> DeleteAsync(Guid id)
{
var db = await this.connectionProvider.CreateConnectionAsync();
var collection = db.GetCollection<Customer>(this.collectionName);

var filter = Builders<Customer>.Filter.Eq(f => f.Id, id);

var result = await collection.DeleteOneAsync(filter);

return result.DeletedCount;
}

public async Task<Customer> GetAsync(Guid id)
{
var filter =
Builders<Customer>.Filter.Eq(f => f.RecordStatus, RecordStatus.Active) &
Builders<Customer>.Filter.Eq(f => f.Id, id);

return await this.GetAsync(filter);
}

public async Task<Customer> GetAsync(Credential credential, Guid id)
{
var filter =
Builders<Customer>.Filter.Eq(f => f.RecordStatus, RecordStatus.Active) &
Builders<Customer>.Filter.Eq(f => f.Company.Code, credential.Company.Code) &
Builders<Customer>.Filter.Eq(f => f.Id, id);

return await this.GetAsync(filter);
}

public async Task<Customer> GetAnyAsync(Guid id)
{
var filter =
Builders<Customer>.Filter.Eq(f => f.Id, id);

return await this.GetAsync(filter);
}

public async Task<Customer> GetAsync(Credential credential, int code)
{
var filter =
Builders<Customer>.Filter.Eq(f => f.RecordStatus, RecordStatus.Active) &
Builders<Customer>.Filter.Eq(f => f.Company.Code, credential.Company.Code) &
Builders<Customer>.Filter.Eq(f => f.Code, code);

return await this.GetAsync(filter);
}

public async Task<Customer> GetAsync(FilterDefinition<Customer> filter)
{
var db = await this.connectionProvider.CreateConnectionAsync();
var collection = db.GetCollection<Customer>(this.collectionName);

var result = await collection.Find(filter).FirstOrDefaultAsync();

return result;
}

public async Task<IdCodeName> GetIdCodeNameAsync(Credential credential, Guid id)
{
var filter =
Builders<Customer>.Filter.Eq(f => f.RecordStatus, RecordStatus.Active) &
Builders<Customer>.Filter.Eq(f => f.Company.Code, credential.Company.Code) &
Builders<Customer>.Filter.Eq(f => f.Id, id);

return await this.GetIdCodeNameAsync(filter);
}

public async Task<IdCodeName> GetAnyIdCodeNameAsync(Guid id)
{
var filter = Builders<Customer>.Filter.Eq(f => f.Id, id);
return await this.GetIdCodeNameAsync(filter);
}

public async Task<IdCodeName> GetIdCodeNameAsync(FilterDefinition<Customer> filter)
{
var db = await this.connectionProvider.CreateConnectionAsync();
var collection = db.GetCollection<Customer>(this.collectionName);

var options = new FindOptions<Customer>
{
Projection = Builders<Customer>.Projection
.Include(p => p.Id)
.Include(p => p.Code)
.Include(p => p.Name),
Limit = 1
};

using var cursor = await collection.FindAsync(filter, options);
while (await cursor.MoveNextAsync())
{
foreach (var item in cursor.Current)
{
return new IdCodeName
{
Id = item.Id,
Code = item.Code,
Name = item.Name
};
}
}

return null;
}

public async Task<IList<Customer>> FindByAccountAsync(Guid accountId, int offset = 0, int limit = 0, bool any = false)
{
var filter = Builders<Customer>.Filter.Eq(f => f.Account.Id, accountId);
if (!any) filter &= Builders<Customer>.Filter.Eq(f => f.RecordStatus, RecordStatus.Active);

return await this.FindAsync(filter, offset, limit);
}

public async Task<IList<Customer>> FindByCompanyAsync(Guid companyId, int offset = 0, int limit = 0, bool any = false)
{
var filter = Builders<Customer>.Filter.Eq(f => f.Company.Id, companyId);
if (!any) filter &= Builders<Customer>.Filter.Eq(f => f.RecordStatus, RecordStatus.Active);

return await this.FindAsync(filter, offset, limit);
}

public async Task<IList<Customer>> FindAsync(FilterDefinition<Customer> filter, int offset = 0, int limit = 0)
{
var l = new List<Customer>();

var db = await this.connectionProvider.CreateConnectionAsync();
var collection = db.GetCollection<Customer>(this.collectionName);

var options = new FindOptions<Customer>();

if (offset > 0)
options.Skip = offset;

if (limit > 0)
options.Limit = limit;

using var cursor = await collection.FindAsync(filter, options);
while (await cursor.MoveNextAsync())
{
l.AddRange(cursor.Current);
}

return l;
}

public async Task<IList<Customer>> FindAllAsync(int offset = 0, int limit = 0)
{
var l = new List<Customer>();

var db = await this.connectionProvider.CreateConnectionAsync();
var collection = db.GetCollection<Customer>(this.collectionName);

var options = new FindOptions<Customer>();

if (offset > 0)
options.Skip = offset;

if (limit > 0)
options.Limit = limit;

using var cursor = await collection.FindAsync(_ => true, options);
while (await cursor.MoveNextAsync())
{
l.AddRange(cursor.Current);
}

return l;
}

public async Task<IList<Guid>> ListIdsAsync(Credential credential, CustomerLevelFilter level, CustomerFilter filter)
{
var _filter =
Builders<Customer>.Filter.Eq(f => f.Company.Code, credential.Company.Code) &
this.GetLevel(level) &
this.GetFilter(credential, filter);

var db = await this.connectionProvider.CreateConnectionAsync();
var collection = db.GetCollection<BsonDocument>(this.collectionName);

var ids = (await collection
.Find(_filter.RenderToBsonDocument())
.Project(new BsonDocument { { "_id", 1 } })
.ToListAsync()).Select(x => x[0].AsGuid).ToList();

return ids;
}

public async Task<bool> ExistsAsync(Guid id, CustomerLevelFilter level)
{
var filter =
Builders<Customer>.Filter.Eq(f => f.RecordStatus, RecordStatus.Active) &
Builders<Customer>.Filter.Eq(f => f.Id, id) &
this.GetLevel(level);

return await this.ExistsAsync(filter);
}

public async Task<bool> ExistsAsync(FilterDefinition<Customer> filter)
{
var db = await this.connectionProvider.CreateConnectionAsync();
var collection = db.GetCollection<Customer>(this.collectionName);

var result = await collection.CountDocumentsAsync(filter);

return result > 0;
}

}
}
