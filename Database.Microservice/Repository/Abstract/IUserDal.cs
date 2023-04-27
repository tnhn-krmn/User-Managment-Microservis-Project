using Database.Microservice.Entities;

namespace Database.Microservice.Repository.Abstract
{
    public interface IUserDal : IBaseRepository<User>
    {
        public User GetUser(User user);
    }
}
