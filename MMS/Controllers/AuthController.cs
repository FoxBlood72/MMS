using Microsoft.AspNetCore.Mvc;
using MMS.BLL.Interfaces;
using MMS.BLL.Models;
using System.Threading.Tasks;

namespace MMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager authManager;

        public AuthController(IAuthManager authManager)
        {
            this.authManager = authManager;
        }

        [HttpPost("Register")]

        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            var result = await this.authManager.Register(registerModel);
            return result ? Ok(result) : BadRequest(result);
        }


        [HttpPost("Login")]

        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var result = await this.authManager.Login(loginModel);
            return result.Success ? Ok(result) : BadRequest("Failed to login");
        }

        [HttpPost("Refresh")]

        public async Task<ActionResult> Refresh([FromBody] RefreshModel refreshModel)
        {
            var result = await authManager.Refresh(refreshModel);
            return !result.Contains("Bad") ? Ok(result) : BadRequest("Failed to refresh");
        }

    }
}
