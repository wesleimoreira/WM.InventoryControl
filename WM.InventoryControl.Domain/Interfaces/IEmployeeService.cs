using WM.InventoryControl.Domain.Entities;

namespace WM.InventoryControl.Domain.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployeeAsync(Guid id);
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    }
}
