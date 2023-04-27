using Presentation.Microservice.DTO;

namespace Presentation.Microservice.Service.Abstract
{
    public interface IAuthService
    {
        public Task<string> GetLogin(LoginDTO user);
    }
}
