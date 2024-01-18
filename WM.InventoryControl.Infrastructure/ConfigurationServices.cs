using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WM.InventoryControl.Domain.Interfaces;
using WM.InventoryControl.Infrastructure.Contexts;
using WM.InventoryControl.Infrastructure.Persistences;
using WM.InventoryControl.Infrastructure.Persistences.Services;

namespace WM.InventoryControl.Infrastructure
{
    public static class ConfigurationServices
    {
        public static void AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ContextSqlServer>(options =>
            {
                options.UseSqlServer(connectionString, builder =>
                {
                    builder.MigrationsAssembly(typeof(ContextSqlServer).Assembly.FullName);
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
