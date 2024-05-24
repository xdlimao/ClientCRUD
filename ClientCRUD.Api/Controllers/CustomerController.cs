using ClientCRUD.Domain.Entities;
using ClientCRUD.Domain.Services;
using ClientCRUD.Infra.Services;
using ClientCRUD.Shared.Parameters;
using ClientCRUD.Shared.Results;
using Microsoft.AspNetCore.Mvc;

namespace ClientCRUD.Api.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;
        public CustomerController(CustomerServices customerServices)
        {
            _customerServices = customerServices;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAll() => Ok(await _customerServices.GetCustomers()); //Done
        [HttpGet("less")]
        public async Task<IActionResult> GetAllWithoutDetails() //Done
        {
            var result = await _customerServices.GetCustomers();
            List<CustomerNoDetails> customers = new List<CustomerNoDetails>();
            for(int i = 0; i < result.Count(); i++)
            {
                customers.Add(CustomerToNoDetails.Convert(result[i]));
            }
            return Ok(customers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByCode([FromRoute] string id) //Done
        {
            var customer = await _customerServices.GetCustomerById(id);
            if (customer == null)
                return NotFound($"Not found the id: {id}");
            return Ok(customer);
        }
        [HttpGet("{id}/less")]
        public async Task<IActionResult> GetByCodeWithoutDetails([FromRoute] string id) //Done
        {
            var result = await _customerServices.GetCustomerById(id);
            if (result == null)
                return NotFound($"Not found the id: {id}");
            return Ok(CustomerToNoDetails.Convert(result));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByCode([FromRoute] string id) //Done
        {
            var result = await _customerServices.DeleteCustomerById(id);
            if (!result) 
                return NotFound($"Not found the id: {id}");
            return Ok($"{id} deleted with success");
        }
        [HttpPost("")]
        public async Task<IActionResult> InsertAllValues([FromBody] CustomerCreate newcustomer) //Done
        {
            var result = await _customerServices.InsertCustomer(CustomerCreateToCustomer.Convert(newcustomer));
            return Ok(result);
        }
        [HttpPost("less")]
        public async Task<IActionResult> InsertMandatoryValues([FromBody] CustomerCreateMinimum newcustomer) //Done
        {
            var result = await _customerServices.InsertCustomer(CustomerCreateMinimunToCustomer.Convert(newcustomer));
            return Ok(result);
        }
        [HttpPut("")]
        public async Task<IActionResult> Update([FromBody] CustomerUpdate updtcustomer)
        {
            var customer = await _customerServices.CompareOldNewCustomer(updtcustomer);
            if (customer == null)
                return NotFound($"Not found the id: {updtcustomer.Id}");
            await _customerServices.UpdateCustomer(customer);
            return Ok(await _customerServices.GetCustomerById(customer.Id.ToString()));
        }
    }
}
