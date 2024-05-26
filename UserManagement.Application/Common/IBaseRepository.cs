using System.Linq.Expressions;

namespace UserManagement.Application.Common
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T?> GetAsync(CancellationToken token, params object[] key);
        Task<TResult> GetPropertyAsync<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, CancellationToken token);
        Task<List<T>> GetAllAsync(CancellationToken token);
        Task AddAsync(T entity, CancellationToken token);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken token);
        void Update(T entity, CancellationToken token);
        void Delete(T result, CancellationToken token);
    }
}
