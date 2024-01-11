using Microsoft.EntityFrameworkCore;
using WM.InventoryControl.Domain.Entities;
using WM.InventoryControl.Domain.Interfaces;
using WM.InventoryControl.Infrastructure.Contexts;

namespace WM.InventoryControl.Infrastructure.Persistences.Services
{
    public record PurchaseService(ContextSqlServer ContextSqlServer) : UnitOfWork(ContextSqlServer), IPurchaseService
    {
        public async Task<IEnumerable<Purchase>> GetAllPurchaseAsync()
        {
            return await ContextSqlServer.Purchases.Include(x => x.PurchaseProducts).ThenInclude(x => x.Product).ToListAsync();
        }

        public async Task<Purchase> GetPurchaseAsync(Guid id)
        {
            return await ContextSqlServer.Purchases.Include(x => x.PurchaseProducts).ThenInclude(x => x.Product).SingleOrDefaultAsync(x => x.Id == id) ?? default!;
        }
    }
}
