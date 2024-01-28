using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WM.InventoryControl.Domain.Entities;

namespace WM.InventoryControl.Infrastructure.Config
{
    public class PurchaseConfig : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Quantity).HasColumnType("int").IsRequired();
            builder.Property(x => x.Price).HasColumnType("decimal(10,2)").IsRequired();
        }
    }
}
