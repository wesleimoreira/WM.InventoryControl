using WM.InventoryControl.Domain.Entities;

namespace WM.InventoryControl.Domain.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task SaveChangesAsync();
        Task<Guid> AddAsync<T>(T entity) where T : EntityBase;
        Task AddRangeAsync<T>(IEnumerable<T> entities) where T : EntityBase;
    }
}
