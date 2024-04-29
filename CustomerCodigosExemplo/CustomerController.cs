// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29

using Ajinsoft.ApiKit.Controllers;
using Ajinsoft.Commons.Params;
using Ajinsoft.Results;
using Ajinsoft.Tools.v3.Customers;
using Microsoft.AspNetCore.Mvc;

namespace Ajinsoft.Tools.Api.Controllers.v3.Customers
{
[Route("v3/customers")]
public class CustomerController : Controller
{
private readonly ICustomerService service;
private readonly ICustomerSearchService searchService;
private readonly IResultService resultService;

public CustomerController(
ICustomerService service,
ICustomerSearchService searchService,
IResultService resultService
)
{
this.service = service;
this.searchService = searchService;
this.resultService = resultService;
}

[Route("{id}")]
[HttpGet]
public async Task<IActionResult> GetAsync(Guid id)
{
try
{
var result = await this.service.GetAsync(id);
return await this.CreateGetResponse(result, this.resultService);
}
catch (Exception e)
{
return await this.CreateExceptionResponse(e);
}
}

[Route("")]
[HttpPost]
public async Task<IActionResult> CreateAsync([FromBody] CustomerParams @params)
{
try
{
var result = await this.service.CreateAsync(@params);
return await this.CreatePostResponse(result, this.resultService);
}
catch (Exception e)
{
return await this.CreateExceptionResponse(e);
}
}

[Route("{id}")]
[HttpPut]
public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] CustomerParams @params)
{
try
{
var result = await this.service.UpdateAsync(id, @params);
return await this.CreatePutResponse(result, this.resultService);
}
catch (Exception e)
{
return await this.CreateExceptionResponse(e);
}
}

[Route("{id}/status")]
[HttpPut]
public async Task<IActionResult> UpdateStatusAsync(Guid id, [FromBody] UpdateStatusParams @params)
{
try
{
var result = await this.service.UpdateStatusAsync(id, @params);
return await this.CreatePutResponse(result, this.resultService);
}
catch (Exception e)
{
return await this.CreateExceptionResponse(e);
}
}

[Route("{id}")]
[HttpDelete]
public async Task<IActionResult> DeleteAsync(Guid id)
{
try
{
var result = await this.service.DeleteAsync(new IdListParams { Ids = new List<Guid> { id } });
return await this.CreateDeleteResponse(result, this.resultService);
}
catch (Exception e)
{
return await this.CreateExceptionResponse(e);
}
}

[Route("delete")]
[HttpPost]
public async Task<IActionResult> DeleteAsync([FromBody] IdListParams @params)
{
try
{
var result = await this.service.DeleteAsync(@params);
return await this.CreatePostResponse(result, this.resultService);
}
catch (Exception e)
{
return await this.CreateExceptionResponse(e);
}
}

[Route("restore")]
[HttpPost]
public async Task<IActionResult> RestoreAsync([FromBody] IdListParams @params)
{
try
{
var result = await this.service.RestoreAsync(@params);
return await this.CreatePostResponse(result, this.resultService);
}
catch (Exception e)
{
return await this.CreateExceptionResponse(e);
}
}

[Route("")]
[HttpGet]
public async Task<IActionResult> FindAsync(CustomerFilter filter)
{
try
{
var result = await this.searchService.FindAsync(filter);
return await this.CreateGetResponse(result, this.resultService);
}
catch (Exception e)
{
return await this.CreateExceptionResponse(e);
}
}

[Route("search")]
[HttpPost]
public async Task<IActionResult> SearchAsync([FromBody] CustomerFilter filter)
{
try
{
var result = await this.searchService.FindAsync(filter);
return await this.CreatePostResponse(result, this.resultService);
}
catch (Exception e)
{
return await this.CreateExceptionResponse(e);
}
}

[Route("search/basic")]
[HttpPost]
public async Task<IActionResult> FindBasicAsync([FromBody] CustomerFilter filter)
{
try
{
var result = await this.searchService.FindBasicAsync(filter);
return await this.CreateGetResponse(result, this.resultService);
}
catch (Exception e)
{
return await this.CreateExceptionResponse(e);
}
}

[Route("list")]
[HttpPost]
public async Task<IActionResult> SearchListAsync([FromBody] CustomerFilter filter)
{
try
{
var result = await this.searchService.ListAsync(filter);
return await this.CreatePostResponse(result, this.resultService);
}
catch (Exception e)
{
return await this.CreateExceptionResponse(e);
}
}

[Route("filters")]
[HttpGet]
public async Task<IActionResult> GetFiltersFieldsAsync()
{
try
{
var result = await this.service.GetFilterFieldsAsync();

return await this.CreateGetResponse(result, this.resultService);
}
catch (Exception e)
{
return await this.CreateExceptionResponse(e);
}
} 
}
}
