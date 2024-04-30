using ClientCRUD.Domain.Entities;
using ClientCRUD.Domain.Services;
using ClientCRUD.Infra.Services;
using ClientCRUD.Shared.Parameters;
using ClientCRUD.Shared.Results;
using Microsoft.AspNetCore.Mvc;

namespace ClientCRUD.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;
        public CustomerController(CustomerServices customerServices)
        {
            _customerServices = customerServices;
        }
        [HttpGet("/customer")]
        public async Task<IActionResult> GetAll() => Ok(await _customerServices.GetCustomers()); //Done
        [HttpGet("/customer/less")]
        public async Task<IActionResult> GetAllWithoutDetails() //Done
        {
            var result = await _customerServices.GetCustomers();
            List<NoDetailsCustomer> customers = new List<NoDetailsCustomer>();
            for(int i = 0; i < result.Count(); i++)
            {
                customers.Add(CustomerToNoDetails.Convert(result[i]));
            }
            return Ok(customers);
        }
        [HttpGet("/customer/{id}")]
        public async Task<IActionResult> GetByCode([FromRoute] string id) //Done
        {
            var customer = await _customerServices.GetCustomerById(id);
            if (customer == null)
                return NotFound($"Not found the id: {id}");
            return Ok(customer);
        }
        [HttpGet("/customer/{id}/less")]
        public async Task<IActionResult> GetByCodeWithoutDetails([FromRoute] string id) //Done
        {
            var result = await _customerServices.GetCustomerById(id);
            if (result == null)
                return NotFound($"Not found the id: {id}");
            return Ok(CustomerToNoDetails.Convert(result));
        }
        [HttpDelete("/customer/{id}")]
        public async Task<IActionResult> DeleteByCode([FromRoute] string id) //Done
        {
            var result = await _customerServices.DeleteCustomerById(id);
            if (!result) 
                return NotFound($"Not found the id: {id}");
            return Ok($"{id} deleted with success");
        }
        [HttpPost("/customer")]
        public async Task<IActionResult> InsertAllValues([FromBody] CreateCustomer newcustomer) //Done
        {
            var result = await _customerServices.InsertCustomer(CreateCustomerToCustomer.Convert(newcustomer));
            return Ok(result);
        }
        [HttpPost("/customer/less")]
        public async Task<IActionResult> InsertMandatoryValues([FromBody] CreateCustomerMinimum newcustomer) //Done
        {
            var result = await _customerServices.InsertCustomer(CreateCustomerMinimunToCustomer.Convert(newcustomer));
            return Ok(result);
        }
        [HttpPut("/customer")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomer updtcustomer)
        {
            var customer = await _customerServices.CompareOldNewCustomer(updtcustomer);
            if (customer == null)
                return NotFound($"Not found the id: {updtcustomer.Id}");
            await _customerServices.UpdateCustomer(customer);
            return Ok(await _customerServices.GetCustomerById(customer.Id.ToString()));
        }
        [HttpGet("")]
        public IActionResult Status()
        {
            return StatusCode(418, "API Online");
        }
    }
}
