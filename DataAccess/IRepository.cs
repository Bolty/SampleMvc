using System.Linq;

namespace DataAccess
{
    public interface IRepository
    {
        IQueryable<T> Get<T>() where T : class;

        T Get<T>(int id) where T : class;

        T Add<T>(T entity) where T : class;

        T Edit<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        

    }
}
