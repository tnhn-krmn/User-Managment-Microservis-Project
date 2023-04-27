using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Microservice.DTO;
using Presentation.Microservice.Service.Abstract;

namespace Presentation.Microservice.Controllers
{
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDTO user)
        {
            var data = _authService.GetLogin(user);
            
            if (data  !=  null)
            {
            HttpContext.Session.SetString("token", data.Result);
            return RedirectToAction("Login");
            }
            return RedirectToAction("Error");
        }
    }
}
