using Microsoft.EntityFrameworkCore;
using WM.InventoryControl.Domain.Entities;
using WM.InventoryControl.Domain.Interfaces;
using WM.InventoryControl.Infrastructure.Contexts;

namespace WM.InventoryControl.Infrastructure.Persistences.Services
{
    internal record UserService(ContextSqlServer ContextSqlServer) : UnitOfWork(ContextSqlServer), IUserService
    {
        public async Task<User> GetUserAsync(string email)
        {
            return await ContextSqlServer
                .Users
                .Where(x => x.Email == email)
                .SingleOrDefaultAsync() ?? default!;
        }
    }
}
