using Database.Microservice.Entities;
using Database.Microservice.Repository.Abstract;

namespace Database.Microservice.Repository.Concrete
{
    public class UserDal : BaseRepository<User, Context>, IUserDal
    {
        public User GetUser(User user)
        {
            using (var context = new Context())
            {
                return context.Users.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            }
        }
    }
}
