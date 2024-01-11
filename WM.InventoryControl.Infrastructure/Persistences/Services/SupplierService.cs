using Microsoft.EntityFrameworkCore;
using WM.InventoryControl.Domain.Entities;
using WM.InventoryControl.Domain.Interfaces;
using WM.InventoryControl.Infrastructure.Contexts;

namespace WM.InventoryControl.Infrastructure.Persistences.Services
{
    public record SupplierService(ContextSqlServer ContextSqlServer) : UnitOfWork(ContextSqlServer), ISupplierService
    {
        public async Task<IEnumerable<Supplier>> GetAllSuppliers()
        {
            return await ContextSqlServer.Suppliers.Include(x => x.Address).Include(x => x.SupplierProducts).ThenInclude(x => x.Product).ToListAsync();
        }

        public async Task<Supplier> GetSupplierAsync(Guid id)
        {
            return await ContextSqlServer.Suppliers.Include(x => x.Address).Include(x => x.SupplierProducts).ThenInclude(x => x.Product).SingleOrDefaultAsync(x => x.Id == id) ?? default!;
        }
    }
}
