using WM.InventoryControl.Domain.Entities;

namespace WM.InventoryControl.Domain.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetProductAsync(Guid id);

        Task<IEnumerable<Product>> GetAllProductAsync();
    }
}
