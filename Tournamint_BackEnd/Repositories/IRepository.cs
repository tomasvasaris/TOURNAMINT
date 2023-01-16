using System.Linq.Expressions;

namespace Tournamint_BackEnd.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> All();
        T Get(int id);
        int Create(T entity);
        void Update(T entity);
        void Remove(T entity);
        int Count();
        bool Exists(int id);
        IEnumerable<T> Find(Expression<Func<T,bool>> predicate);
    }
}
