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
        public IActionResult GetAll() => Ok(_customerServices.GetCustomers()); //Done
        [HttpGet("/customer/less")]
        public IActionResult GetAllWithoutDetails() //Done
        {
            var result = _customerServices.GetCustomers();
            List<NoDetailsCustomer> customers = new List<NoDetailsCustomer>();
            for(int i = 0; i < result.Count(); i++)
            {
                customers.Add(new NoDetailsCustomer()
                {
                    Code = result[i].Code,
                    Type = result[i].Type,
                    Name = result[i].Name,
                    Description = result[i].Description,
                    IdentityType = result[i].IdentityType,
                    Identity = result[i].Identity,
                    Addresses = result[i].Addresses,
                    Phones = result[i].Phones,
                    Emails = result[i].Emails
                });
            }
            return Ok(customers);
        }
        [HttpGet("/customer/{id}")]
        public IActionResult GetByCode([FromRoute] string id) //Done
        {
            var customer = _customerServices.GetCustomerById(id);
            if (customer == null)
                return NotFound($"Not found the id: {id}");
            return Ok(customer);
        }
        [HttpGet("/customer/{id}/less")]
        public IActionResult GetByCodeWithoutDetails([FromRoute] string id) //Done
        {
            var result = _customerServices.GetCustomerById(id);
            if (result == null)
                return NotFound($"Not found the id: {id}");
            NoDetailsCustomer customer = new()
            {
                Code = result.Code,
                Type = result.Type,
                Name = result.Name,
                Description = result.Description,
                IdentityType = result.IdentityType,
                Identity = result.Identity,
                Addresses = result.Addresses,
                Phones = result.Phones,
                Emails = result.Emails
            };
            return Ok(customer);
        }
        [HttpDelete("/customer/{id}")]
        public IActionResult DeleteByCode([FromRoute] string id) //Done
        {
            var result = _customerServices.DeleteCustomerById(id);
            if (!result) 
                return NotFound($"Not found the id: {id}");
            return Ok($"{id} deleted with success");
        }
        [HttpPost("/customer")]
        public IActionResult InsertAllValues([FromBody] CreateCustomer newcustomer) //Done
        {
            Customer customer = new()
            {
                Id = Guid.NewGuid(),
                Code = newcustomer.Code,
                Name = newcustomer.Name,
                Type = newcustomer.Type,
                Nickname = newcustomer.Nickname,
                Description = newcustomer.Description,
                PersonType = newcustomer.PersonType,
                IdentityType = newcustomer.IdentityType,
                Identity = newcustomer.Identity,
                Birthdate = newcustomer.Birthdate,
                Enabled = true,
                Addresses = newcustomer.Addresses,
                Phones = newcustomer.Phones,
                Emails = newcustomer.Emails,
                Avatar = newcustomer.Avatar,
                Image = newcustomer.Image,
                Color = newcustomer.Color,
                ReferenceCode = newcustomer.ReferenceCode,
                Note = newcustomer.Note
            };
            var result = _customerServices.InsertCustomer(customer);
            return Ok(result);
        }
        [HttpPost("/customer/less")]
        public IActionResult InsertMandatoryValues([FromBody] CreateCustomerMinimum newcustomer) //Done
        {
            Customer customer = new()
            {
                Id = Guid.NewGuid(),
                Code = newcustomer.Code,
                Type = newcustomer.Type,
                Addresses = newcustomer.Addresses,
                Emails = newcustomer.Emails,
                Phones = newcustomer.Phones,
                Enabled = true
            };
            var result = _customerServices.InsertCustomer(customer);
            return Ok(result);
        }
        //[HttpPut("/customer")]
        //public IActionResult Update([FromBody] UpdateCustomer updtcustomer)
        //{
        //    _customerServices.Update();
        //    return Ok(_customerServices.GetCustomerById());
        //}
        [HttpGet("")]
        public IActionResult Status()
        {
            return StatusCode(418, "API Online");
        }
    }
}
