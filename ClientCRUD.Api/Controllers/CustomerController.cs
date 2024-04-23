using ClientCRUD.Domain.Repositories;
using ClientCRUD.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClientCRUD.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [HttpGet("/customer")]
        public IActionResult GetAll() => Ok(_customerRepository.GetAll()); //Done
        //[HttpGet("/customer/{id}")]
        //public IActionResult GetByCode([FromRoute] string id) //Done
        //{
        //    var entity = _customerRepository.GetByCode(id);
        //    if (entity == null)
        //        return NotFound("Not found that id");
        //    return Ok(entity);
        //}
        //[HttpDelete("/customer/{id}")]
        //public IActionResult DeleteByCode([FromRoute] string id) //Done
        //{
        //    if (_customerRepository.GetByCode(id) == null)
        //        return NotFound("Not found that id");
        //    _customerRepository.Delete(id);
        //    return Ok("Deleted " + id);
        //}
        ////Criar Bodys para o de baixo
        //[HttpPost("/customer")]
        //public IActionResult Insert([FromQuery] string namerr)
        //{
        //    _customerRepository.Insert(namerr);
        //    return Ok("Criado com sucesso");
        //}
        //[HttpPut("/customer")]
        //public IActionResult Update([FromQuery] string name, [FromQuery] string newname)
        //{
        //    //Lógica se existe ou não
        //    _customerRepository.Update(name, newname);
        //    return Ok(_customerRepository.GetByCode(newname));
        //}
        [HttpGet("")]
        public IActionResult Status()
        {
            return StatusCode(418, "API Online");
        }
    }
}
