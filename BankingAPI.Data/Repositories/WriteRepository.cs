using BankingAPI.Core.Entities.Common;
using BankingAPI.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BankingAPI.Data.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        readonly DbContext context;
        public WriteRepository(DbContext context)
        {
            this.context = context;
        }
        protected DbSet<T> Table => context.Set<T>();

        public virtual async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public virtual async Task AddAsync(IEnumerable<T> entities)
        {
            if (entities is not null && !entities.Any())
                return;

            await Table.AddRangeAsync(entities);
        }
        public virtual void Update(T entity)
        {
            Table.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            Table.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
        public virtual async Task DeleteAsync(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
                Table.Attach(entity);

            Table.Remove(entity);
        }
        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await Table.FindAsync(id);
            await DeleteAsync(entity);
        }

        public virtual async Task DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            context.RemoveRange(Table.Where(predicate));
        }
    }
}
