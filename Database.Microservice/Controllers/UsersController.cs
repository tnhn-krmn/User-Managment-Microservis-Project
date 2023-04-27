using Database.Microservice.Entities;
using Database.Microservice.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Database.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUserList")]
        public List<User> GetUserList()
        {
            return _userService.GetAll();
        }

        [HttpPost("UserAdd")]
        public IActionResult UserAdd(User user)
        {
            _userService.Add(user);
            return Ok();
        }

        [HttpPost("UserUpdate")]
        public IActionResult UserUpdate(User user)
        {
            _userService.Update(user);
            return Ok();
        }

        [HttpPost("UserDelete")]
        public IActionResult UserDelete(User user)
        {
            _userService.Delete(user);
            return Ok();
        }

        [HttpPost("GetUserAuthentication")]
        public IActionResult GetUserAuthentication(User user)
        {
            var data = _userService.GetUser(user);
            if(data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }
    }
}
