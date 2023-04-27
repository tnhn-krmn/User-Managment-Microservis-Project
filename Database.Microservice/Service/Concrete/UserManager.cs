using Azure.Core;
using Database.Microservice.Entities;
using Database.Microservice.Repository.Abstract;
using Database.Microservice.Service.Abstract;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static Database.Microservice.Settings.Settings;

namespace Database.Microservice.Service.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly TokenSettings _tokenSettings;

        public UserManager(IOptions<TokenSettings> tokenSettings, IUserDal userDal)
        {
            _userDal = userDal;
            _tokenSettings = tokenSettings.Value;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public List<User> GetAll()
        {
            return _userDal.GetList();
        }

        public User GetUser(User user)
        {
            var data = _userDal.GetUser(user);
            if(data != null)
            {
                return data;
            }
            return null;

        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
    }
}
