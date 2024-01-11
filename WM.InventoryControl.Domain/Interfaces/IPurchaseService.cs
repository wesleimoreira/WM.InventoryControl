using WM.InventoryControl.Domain.Entities;

namespace WM.InventoryControl.Domain.Interfaces
{
    public interface IPurchaseService
    {
        Task<Purchase> GetPurchaseAsync(Guid id);
        Task<IEnumerable<Purchase>> GetAllPurchaseAsync();
    }
}
