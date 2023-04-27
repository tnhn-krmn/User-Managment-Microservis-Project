using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Presentation.Microservice.DTO;
using Presentation.Microservice.Service.Abstract;

namespace Presentation.Microservice.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(LoginDTO user)
        {
            var token = HttpContext.Session.GetString("token");

            var data = _userService.UserAdd(user, token);
            if(data == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(UserUpdateDto user)
        {
            var token = HttpContext.Session.GetString("token");

            var data = _userService.UserUpdate(user, token);
            if (data == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(UserUpdateDto user)
        {
            var token = HttpContext.Session.GetString("token");

            var data = _userService.UserDelete(user, token);
            if (data == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
