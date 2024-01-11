using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WM.InventoryControl.Domain.Entities;

namespace WM.InventoryControl.Infrastructure.Config
{
    public class PurchaseProductConfig : IEntityTypeConfiguration<PurchaseProduct>
    {
        public void Configure(EntityTypeBuilder<PurchaseProduct> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.PurchaseProducts)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.ProductId);

            builder
                .HasOne(x => x.Purchase)
                .WithMany(x => x.PurchaseProducts)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.PurchaseId);
        }
    }
}
