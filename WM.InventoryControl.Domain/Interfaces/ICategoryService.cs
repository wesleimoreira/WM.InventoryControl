using WM.InventoryControl.Domain.Entities;

namespace WM.InventoryControl.Domain.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> GetCategoryAsync(Guid id);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
    }
}
