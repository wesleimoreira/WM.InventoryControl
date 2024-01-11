using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WM.InventoryControl.Domain.Interfaces;
using WM.InventoryControl.Infrastructure.Contexts;
using WM.InventoryControl.Infrastructure.Persistences;
using WM.InventoryControl.Infrastructure.Persistences.Services;

namespace WM.InventoryControl.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static void AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ContextSqlServer>(options =>
            {
                options.UseSqlServer(connectionString, a =>
                {
                    a.MigrationsAssembly("WM.InventoryControl.Api");
                });
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ISupplierService, SupplierService>();
        }
    }
}
