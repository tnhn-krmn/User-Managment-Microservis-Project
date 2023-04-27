using System.Linq.Expressions;

namespace Database.Microservice.Repository.Abstract
{
    public interface IBaseRepository<T> where T : class, new()
    {
        List<T> GetList();

        void Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
    }
}
