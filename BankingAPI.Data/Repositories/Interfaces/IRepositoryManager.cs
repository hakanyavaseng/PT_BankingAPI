using BankingAPI.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace BankingAPI.Data.Repositories.Interfaces
{
    public interface IRepositoryManager : IDisposable
    {
        DbContext DbContext { get; }
        IReadRepository<T> GetReadRepository<T>() where T : BaseEntity;
        IWriteRepository<T> GetWriteRepository<T>() where T : BaseEntity;
        Task<int> SaveAsync();
        int Save();
    }
}
