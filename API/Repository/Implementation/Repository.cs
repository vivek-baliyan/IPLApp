using System.Linq.Expressions;
using API.Data;
using API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        internal DbSet<T> _dbSet;
        public Repository(DataContext db)
        {
            _dbSet = db.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public async Task<IEnumerable<T>> GetAllAsync(string? includeroperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (includeroperties != null)
            {
                foreach (var includeProp in includeroperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.ToListAsync();
        }
        public async Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, string? includeroperties = null)
        {
            IQueryable<T> query = _dbSet.Where(filter);
            if (includeroperties != null)
            {
                foreach (var includeProp in includeroperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.FirstOrDefaultAsync();
        }
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }
    }
}