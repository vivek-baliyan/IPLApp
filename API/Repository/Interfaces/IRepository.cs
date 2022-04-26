using System.Linq.Expressions;

namespace API.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, string? includeroperties = null);
        Task<IEnumerable<T>> GetAllAsync(string? includeroperties = null);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}