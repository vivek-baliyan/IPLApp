
using System.Linq.Expressions;

namespace API.Data.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeroperties = null);
        Task<IEnumerable<T>> GetAll(string? includeroperties = null);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}