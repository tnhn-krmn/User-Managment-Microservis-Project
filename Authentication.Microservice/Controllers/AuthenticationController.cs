using Authentication.Microservice.Dto;
using Authentication.Microservice.Service.Abstract;
using Database.Microservice.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Authentication.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService _authenticationService;
        private IConfiguration _configuration;
        public AuthenticationController(IAuthenticationService authenticationService, IConfiguration configuration)
        {
            _authenticationService = authenticationService;
            _configuration = configuration;
        }

        [HttpPost("UserAuthentication")]
        public async Task<IActionResult> UserAuthentication(LoginDto user)
        {
            var data = await _authenticationService.UserAuthentication(user);
            HttpContext.Session.SetString("JWToken", data);
            if (data == null)
            {
                return new UnauthorizedResult();
            }
            return Ok(data);
        }

    }
}
