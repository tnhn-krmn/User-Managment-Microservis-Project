using Presentation.Microservice.DTO;

namespace Presentation.Microservice.Service.Abstract
{
    public interface IUserService
    {
        public Task<bool> UserAdd(LoginDTO user, string token);
        public Task<bool> UserUpdate(UserUpdateDto user, string token);
        public Task<bool> UserDelete(UserUpdateDto user, string token);
    }
}
