using User.Microservice.Dto;

namespace User.Microservice.Service.Abstract
{
    public interface IUserService
    {
        public Task<bool> UserAdd(UserDto user, string token);
        public Task<UserDto> UserUpdate(UserUpdateDto user);
        public Task<bool> UserDelete(UserUpdateDto user);
    }
}
