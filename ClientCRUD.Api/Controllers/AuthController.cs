using ClientCRUD.Domain.Entities;
using ClientCRUD.Domain.Services;
using ClientCRUD.Infra.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClientCRUD.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly IUserServices _userService;
        public AuthController(TokenService tokenService, UserServices userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Auth(
            )
        {
            var entity = await _userService.SingInUser("kaiky", "pastel");
            if (entity != null)
                return Ok(_tokenService.Create(entity));
            return Unauthorized("Login or password wrong stupid");
        }
    }
}
