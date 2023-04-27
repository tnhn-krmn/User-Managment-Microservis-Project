

using Authentication.Microservice.Dto;

namespace Authentication.Microservice.Service.Abstract
{
    public interface IAuthenticationService
    {
        public Task<string> UserAuthentication(LoginDto user); 
    }
}
