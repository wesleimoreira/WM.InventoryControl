using Microsoft.EntityFrameworkCore;
using WM.InventoryControl.Domain.Entities;
using WM.InventoryControl.Domain.Interfaces;
using WM.InventoryControl.Infrastructure.Contexts;

namespace WM.InventoryControl.Infrastructure.Persistences.Services
{
    public record EmployeeService(ContextSqlServer ContextSqlServer) : UnitOfWork(ContextSqlServer), IEmployeeService
    {
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await ContextSqlServer.Employees.Include(x => x.Address).Include(x => x.Company).ToListAsync();
        }

        public async Task<Employee> GetEmployeeAsync(Guid id)
        {
            return await ContextSqlServer.Employees.Include(x => x.Address).Include(x => x.Company).SingleOrDefaultAsync(x => x.Id == id) ?? default!;
        }

        public async Task<Employee> GetEmployeeByEmailAsync(string email)
        {
            return await ContextSqlServer.Employees.Include(x => x.Address).Include(x => x.Company).SingleOrDefaultAsync(x => x.Email == email) ?? default!;
        }
    }
}
