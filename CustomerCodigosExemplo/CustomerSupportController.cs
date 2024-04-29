// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2024-04-29

using Ajinsoft.ApiKit.Controllers;
using Ajinsoft.Results;
using Ajinsoft.Tools.v3.Customers;
using Microsoft.AspNetCore.Mvc;

namespace Ajinsoft.Tools.Api.Controllers.v3.Customers
{
[Route("v3/customer-supports")]
public class CustomerSupportController : Controller
{
private readonly ICustomerService service;
private readonly IResultService resultService;

public CustomerSupportController(
ICustomerService service,
IResultService resultService)
{
this.service = service;
this.resultService = resultService;
}

[Route("")]
[HttpGet]
public async Task<IActionResult> GetSupportAsync()
{
try
{
var result = await this.service.GetSupportAsync();
return await this.CreateGetResponse(result, this.resultService);
}
catch (Exception e)
{
return await this.CreateExceptionResponse(e);
}
}
}
}
