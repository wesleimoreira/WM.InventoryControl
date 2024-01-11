using WM.InventoryControl.Domain.Entities;

namespace WM.InventoryControl.Domain.Interfaces
{
    public interface ISupplierService
    {
        Task<Supplier> GetSupplierAsync(Guid id);
        Task<IEnumerable<Supplier>> GetAllSuppliers();
    }
}
