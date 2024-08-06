using BankingAPI.Core.Entities.Common;
using System.Linq.Expressions;

namespace BankingAPI.Data.Repositories.Interfaces
{
    public interface IWriteRepository<T> where T : BaseEntity
    {
        //Create
        Task AddAsync(T entity);
        Task AddAsync(IEnumerable<T> entities);
        //Update
        Task UpdateAsync(T entity);
        void Update(T entity);
        //Delete
        Task DeleteAsync(T entity);
        Task DeleteAsync(Expression<Func<T, bool>> predicate);
    }
}
