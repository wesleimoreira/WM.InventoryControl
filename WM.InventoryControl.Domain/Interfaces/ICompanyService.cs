using WM.InventoryControl.Domain.Entities;

namespace WM.InventoryControl.Domain.Interfaces
{
    public interface ICompanyService
    {
        Task<Company> GetCompanyAsync(Guid id);
        Task<IEnumerable<Company>> GetAllCompaniesAsync();
    }
}
