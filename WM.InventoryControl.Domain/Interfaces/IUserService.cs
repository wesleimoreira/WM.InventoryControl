using WM.InventoryControl.Domain.Entities;

namespace WM.InventoryControl.Domain.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserAsync(string email);
    }
}
