using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WM.InventoryControl.Domain.Entities;

namespace WM.InventoryControl.Infrastructure.Config
{
    public class SaleProductConfig : IEntityTypeConfiguration<SaleProduct>
    {
        public void Configure(EntityTypeBuilder<SaleProduct> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.SaleProducts)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.ProductId);

            builder
                .HasOne(x => x.Sale)
                .WithMany(x => x.SaleProducts)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.SaleId);
        }
    }
}
