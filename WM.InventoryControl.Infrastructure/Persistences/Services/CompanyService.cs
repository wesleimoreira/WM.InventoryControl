using Microsoft.EntityFrameworkCore;
using WM.InventoryControl.Domain.Entities;
using WM.InventoryControl.Domain.Interfaces;
using WM.InventoryControl.Infrastructure.Contexts;

namespace WM.InventoryControl.Infrastructure.Persistences.Services
{
    public record CompanyService(ContextSqlServer ContextSqlServer) : UnitOfWork(ContextSqlServer), ICompanyService
    {
        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            return await ContextSqlServer.Companies.Include(x => x.Address).Include(x => x.Employees).ToListAsync();
        }

        public async Task<Company> GetCompanyAsync(Guid id)
        {
            return await ContextSqlServer.Companies.Include(x => x.Address).Include(x => x.Employees).SingleOrDefaultAsync(x => x.Id == id) ?? default!;
        }
    }
}
