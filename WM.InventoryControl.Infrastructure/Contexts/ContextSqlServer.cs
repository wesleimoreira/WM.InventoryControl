using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WM.InventoryControl.Domain.Entities;

namespace WM.InventoryControl.Infrastructure.Contexts
{
    public class ContextSqlServer(DbContextOptions<ContextSqlServer> options) : DbContext(options)
    {
        public DbSet<Sale> Sales => Set<Sale>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Purchase> Purchases => Set<Purchase>();
        public DbSet<Supplier> Suppliers => Set<Supplier>();
        public DbSet<Category> Categories => Set<Category>();


        public DbSet<SaleProduct> SaleProducts => Set<SaleProduct>();
        public DbSet<PurchaseProduct> PurchaseProducts => Set<PurchaseProduct>();
        public DbSet<SupplierProduct> SupplierProducts => Set<SupplierProduct>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
