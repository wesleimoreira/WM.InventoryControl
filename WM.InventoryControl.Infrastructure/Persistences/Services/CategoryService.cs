using Microsoft.EntityFrameworkCore;
using WM.InventoryControl.Domain.Entities;
using WM.InventoryControl.Domain.Interfaces;
using WM.InventoryControl.Infrastructure.Contexts;

namespace WM.InventoryControl.Infrastructure.Persistences.Services
{
    public record CategoryService(ContextSqlServer ContextSqlServer) : UnitOfWork(ContextSqlServer), ICategoryService
    {
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await ContextSqlServer.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(Guid id)
        {
            return await ContextSqlServer.Categories.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id) ?? default!;
        }
    }
}
