using Microsoft.AspNetCore.Mvc;
using WebAPI.Requests;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ILoginService _loginApiService;

        public LoginController(ILogger<LoginController> logger, ILoginService loginApiService)
        {
            _logger = logger;
            _loginApiService = loginApiService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            return Ok(await _loginApiService.Login(email, password));
        }
    }
}