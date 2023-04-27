using Database.Microservice.Entities;

namespace Database.Microservice.Service.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        public User GetUser(User user);
    }
}
