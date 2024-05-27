using ClientCRUD.Domain.Services;
using ClientCRUD.Infra.Services;
using ClientCRUD.Shared.Parameters;
using ClientCRUD.Shared.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClientCRUD.Api.Controllers
{
    [ApiController]
    [Route("customer")]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;
        private readonly IUserServices _userServices;
        public CustomerController(CustomerServices customerServices, UserServices userServices)
        {
            _customerServices = customerServices;
            _userServices = userServices;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAll() //Done
        {
            int[] permissions = [1, 2];
            if (!await _userServices.VerifyUserAccess(Guid.Parse(HttpContext.User.Claims.First(c => c.Type == "_id").Value), permissions))
                return StatusCode(403);
            return Ok(await _customerServices.GetCustomers());
        }
        [HttpPost("query")]
        public async Task<IActionResult> GetAllWithLimitAndSkip([FromBody] CustomerLimitAndSkip options)
        {
            int[] permissions = [1, 2];
            if (!await _userServices.VerifyUserAccess(Guid.Parse(HttpContext.User.Claims.First(c => c.Type == "_id").Value), permissions))
                return StatusCode(403);
            return Ok(await _customerServices.GetCustomersWithLimitAndSkip(options.limit, options.skip));
        }

        [HttpGet("less")]
        public async Task<IActionResult> GetAllWithoutDetails() //Done
        {
            int[] permissions = [1, 2];
            if (!await _userServices.VerifyUserAccess(Guid.Parse(HttpContext.User.Claims.First(c => c.Type == "_id").Value), permissions))
                return StatusCode(403);
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
            int[] permissions = [1, 2];
            if (!await _userServices.VerifyUserAccess(Guid.Parse(HttpContext.User.Claims.First(c => c.Type == "_id").Value), permissions))
                return StatusCode(403);
            var customer = await _customerServices.GetCustomerById(id);
            if (customer == null)
                return NotFound($"Not found the id: {id}");
            return Ok(customer);
        }
        [HttpGet("{id}/less")]
        public async Task<IActionResult> GetByCodeWithoutDetails([FromRoute] string id) //Done
        {
            int[] permissions = [1, 2];
            if (!await _userServices.VerifyUserAccess(Guid.Parse(HttpContext.User.Claims.First(c => c.Type == "_id").Value), permissions))
                return StatusCode(403);
            var result = await _customerServices.GetCustomerById(id);
            if (result == null)
                return NotFound($"Not found the id: {id}");
            return Ok(CustomerToNoDetails.Convert(result));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByCode([FromRoute] string id) //Done
        {
            int[] permissions = [1];
            if (!await _userServices.VerifyUserAccess(Guid.Parse(HttpContext.User.Claims.First(c => c.Type == "_id").Value), permissions))
                return StatusCode(403);
            var result = await _customerServices.DeleteCustomerById(id);
            if (!result) 
                return NotFound($"Not found the id: {id}");
            return Ok($"{id} deleted with success");
        }
        [HttpPost("")]
        public async Task<IActionResult> InsertAllValues([FromBody] CustomerCreate newcustomer)
        {
            int[] permissions = [1];
            if (!await _userServices.VerifyUserAccess(Guid.Parse(HttpContext.User.Claims.First(c => c.Type == "_id").Value), permissions))
                return StatusCode(403);
            var result = await _customerServices.InsertCustomer(CustomerCreateToCustomer.Convert(newcustomer));
            return Ok(result);
        }
        [HttpPost("less")]
        public async Task<IActionResult> InsertMandatoryValues([FromBody] CustomerCreateMinimum newcustomer)
        {
            int[] permissions = [1];
            if (!await _userServices.VerifyUserAccess(Guid.Parse(HttpContext.User.Claims.First(c => c.Type == "_id").Value), permissions))
                return StatusCode(403);
            var result = await _customerServices.InsertCustomer(CustomerCreateMinimunToCustomer.Convert(newcustomer));
            return Ok(result);
        }
        [HttpPut("")]
        public async Task<IActionResult> Update([FromBody] CustomerUpdate updtcustomer)
        {
            int[] permissions = [1];
            if (!await _userServices.VerifyUserAccess(Guid.Parse(HttpContext.User.Claims.First(c => c.Type == "_id").Value), permissions))
                return StatusCode(403);
            var customer = await _customerServices.CompareOldNewCustomer(updtcustomer);
            if (customer == null)
                return NotFound($"Not found the id: {updtcustomer.Id}");
            await _customerServices.UpdateCustomer(customer);
            return Ok(await _customerServices.GetCustomerById(customer.Id.ToString()));
        }
    }
}
