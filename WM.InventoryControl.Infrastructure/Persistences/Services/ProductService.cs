using Microsoft.EntityFrameworkCore;
using WM.InventoryControl.Domain.Entities;
using WM.InventoryControl.Domain.Interfaces;
using WM.InventoryControl.Infrastructure.Contexts;

namespace WM.InventoryControl.Infrastructure.Persistences.Services
{
    public record ProductService(ContextSqlServer ContextSqlServer) : UnitOfWork(ContextSqlServer), IProductService
    {
        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            return await ContextSqlServer.Products.Include(x => x.Category).Include(x => x.SupplierProducts).ThenInclude(x => x.Supplier).ToListAsync();
        }

        public async Task<Product> GetProductAsync(Guid id)
        {
            return await ContextSqlServer.Products.Include(x => x.Category).Include(x => x.SupplierProducts).ThenInclude(x => x.Supplier).SingleOrDefaultAsync(x => x.Id == id) ?? default!;
        }
    }
}
