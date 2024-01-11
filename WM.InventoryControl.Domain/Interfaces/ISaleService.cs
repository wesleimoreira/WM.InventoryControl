using WM.InventoryControl.Domain.Entities;

namespace WM.InventoryControl.Domain.Interfaces
{
    public interface ISaleService
    {
        Task<Sale> GetSaleAsync(Guid id);

        Task<IEnumerable<Sale>> GetAllSalesAsync();
    }
}
