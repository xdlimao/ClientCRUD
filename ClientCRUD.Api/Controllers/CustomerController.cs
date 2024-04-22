using ClientCRUD.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ClientCRUD.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class CustomerController : ControllerBase
    {
        [HttpGet("/customer")]
        public List<Customer> GetAll()
        {
        }
        [HttpGet("/customer/{code:int}")]
        public Customer GetByCode(int code)
        {
        }
    }
}
