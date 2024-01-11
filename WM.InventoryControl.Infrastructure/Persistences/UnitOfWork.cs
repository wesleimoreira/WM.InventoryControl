using WM.InventoryControl.Domain.Entities;
using WM.InventoryControl.Domain.Interfaces;
using WM.InventoryControl.Infrastructure.Contexts;

namespace WM.InventoryControl.Infrastructure.Persistences
{
    public record UnitOfWork(ContextSqlServer ContextSqlServer) : IUnitOfWork
    {
        public async Task<Guid> AddAsync<T>(T entity) where T : EntityBase
        {
            var result = await ContextSqlServer.Set<T>().AddAsync(entity);
            return result.Entity.Id;
        }
        public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : EntityBase
        {
            await ContextSqlServer.Set<T>().AddRangeAsync(entities);
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await ContextSqlServer.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async ValueTask DisposeAsync()
        {
            await ContextSqlServer.DisposeAsync();
            GC.SuppressFinalize(this);
        }
    }
}
