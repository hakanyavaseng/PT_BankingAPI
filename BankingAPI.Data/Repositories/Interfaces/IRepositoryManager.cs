using BankingAPI.Core.Entities.Common;

namespace BankingAPI.Data.Repositories.Interfaces
{
    public interface IRepositoryManager : IDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : BaseEntity;
        IWriteRepository<T> GetWriteRepository<T>() where T : BaseEntity;
        Task<int> SaveAsync();
        int Save();
    }
}
