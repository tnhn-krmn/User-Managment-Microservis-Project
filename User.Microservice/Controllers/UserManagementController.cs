using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.Microservice.Dto;
using User.Microservice.Service.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace User.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserManagementController : ControllerBase
    {
       private IUserService _userService;

        public UserManagementController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("UserAdd")]
        public async Task<bool> UserAdd([FromBody] UserDto user, string token)
        {
            var data = await _userService.UserAdd(user, token);
            if(data != false)
            {
                return true;
            }
            return false;
        }

        [HttpPost("UserUpdate")]
        public async Task<UserDto> Put([FromBody] UserUpdateDto user)
        {
            var data = await _userService.UserUpdate(user);
            if(data != null)
            {
                return data;
            }
            return null;
        }

        [HttpPost("UserDelete")]
        public async Task<bool> Delete([FromBody] UserUpdateDto user)
        {
            var data = await _userService.UserDelete(user);
            if(data != false)
            {
                return true;
            }
            return false;
        }
    }
}
