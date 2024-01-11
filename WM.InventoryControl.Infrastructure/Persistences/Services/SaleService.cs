using Microsoft.EntityFrameworkCore;
using WM.InventoryControl.Domain.Entities;
using WM.InventoryControl.Domain.Interfaces;
using WM.InventoryControl.Infrastructure.Contexts;

namespace WM.InventoryControl.Infrastructure.Persistences.Services
{
    public record SaleService(ContextSqlServer ContextSqlServer) : UnitOfWork(ContextSqlServer), ISaleService
    {
        public async Task<IEnumerable<Sale>> GetAllSalesAsync()
        {
            return await ContextSqlServer.Sales.Include(x => x.SaleProducts).ThenInclude(x => x.Product).ToListAsync();
        }

        public async Task<Sale> GetSaleAsync(Guid id)
        {
            return await ContextSqlServer.Sales.Include(x => x.SaleProducts).ThenInclude(x => x.Product).SingleOrDefaultAsync(x => x.Id == id) ?? default!;
        }
    }
}
