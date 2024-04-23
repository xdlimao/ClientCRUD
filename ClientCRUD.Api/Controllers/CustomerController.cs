using ClientCRUD.Domain.Entities;
using ClientCRUD.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClientCRUD.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class CustomerController : ControllerBase
    {
        [HttpGet("/customer")]
        public IActionResult GetAll([FromServices] CustomerRepository customerRepository) => Ok(customerRepository.GetAll());
        [HttpGet("/customer/{name}")]
        public IActionResult GetByCode([FromRoute] string name, [FromServices] CustomerRepository customerRepository) => Ok(customerRepository.GetByCode(name));
        [HttpDelete("/customer/{name}")]
        public IActionResult DeleteByCode([FromRoute] string name, [FromServices] CustomerRepository customerRepository)
        {
            customerRepository.Delete(name);
            return Ok("Deleted "+name);
        }
        [HttpPut("/customer")]
        public IActionResult Insert([FromServices] CustomerRepository customerRepository, [FromQuery] string namerr) 
        {
            customerRepository.Insert(namerr);
            return Ok("Criado com sucesso");
        }
        [HttpGet("")]
        public IActionResult Status()
        {
            return Ok("API Online");
        }
    }
}
