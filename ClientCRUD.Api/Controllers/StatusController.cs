using Microsoft.AspNetCore.Mvc;

namespace ClientCRUD.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class StatusController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult Status()
        {
            return StatusCode(418, "API Online");
        }
    }
}
