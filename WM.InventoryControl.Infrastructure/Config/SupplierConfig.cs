using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WM.InventoryControl.Domain.Entities;

namespace WM.InventoryControl.Infrastructure.Config
{
    public class SupplierConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("nvarchar(150)").IsRequired();

            // EF
            builder
                .HasOne(x => x.Address)
                .WithOne(x => x.Supplier)
                .HasForeignKey<Supplier>(x => x.AddressId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
