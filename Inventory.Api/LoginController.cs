using Inventory.Core;
using Inventory.Domain.DomainModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Inventory.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController: ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var response = await _loginService.Login(request);
            return Ok(response);
        }
    }
}
