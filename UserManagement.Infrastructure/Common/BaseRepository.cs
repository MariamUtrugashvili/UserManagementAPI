using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UserManagement.Application.Common;

namespace UserManagement.Infrastructure.Common
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        #region Protected
        protected UserManagementDbContext _context;
        protected DbSet<T> _dbSet;
        #endregion

        #region ctor
        public BaseRepository(UserManagementDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        #endregion

        #region Methods
        public async Task<T?> GetAsync(CancellationToken token, params object[] key)
        {
            return await _dbSet.FindAsync(key, token);
        }

        public async Task<TResult> GetPropertyAsync<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, CancellationToken token)
        {
            return await _dbSet.Where(predicate).Select(selector).SingleAsync(token);
        }

        public async Task<List<T>> GetAllAsync(CancellationToken token)
        {
            return await _dbSet.ToListAsync(token);
        }

        public async Task AddAsync(T entity, CancellationToken token)
        {
            await _dbSet.AddAsync(entity, token);
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken token)
        {
            return _dbSet.AnyAsync(predicate, token);
        }

        public void Update(T entity, CancellationToken token)
        {
            if (entity == null)
                return;
            _dbSet.Update(entity);
        }

        public void Delete(T result, CancellationToken token)
        {
            _dbSet!.Remove(result);
        }
        #endregion
    }
}
