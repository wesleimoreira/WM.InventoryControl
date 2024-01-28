using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WM.InventoryControl.Domain.Entities;

namespace WM.InventoryControl.Infrastructure.Config
{
    public class SupplierProductConfing : IEntityTypeConfiguration<SupplierProduct>
    {
        public void Configure(EntityTypeBuilder<SupplierProduct> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                  .HasOne(x => x.Product)
                  .WithMany(x => x.SupplierProducts)
                  .HasPrincipalKey(x => x.Id)
                  .HasForeignKey(x => x.ProductId);

            builder
                .HasOne(x => x.Supplier)
                .WithMany(x => x.SupplierProducts)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.SupplierId);
        }
    }
}
