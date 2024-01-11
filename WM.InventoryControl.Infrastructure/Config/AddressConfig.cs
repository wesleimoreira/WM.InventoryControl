using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WM.InventoryControl.Domain.Entities;

namespace WM.InventoryControl.Infrastructure.Config
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Country).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.State).HasColumnType("nvarchar(2)").IsRequired();
            builder.Property(x => x.City).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.District).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.Street).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.ZipCode).HasColumnType("nvarchar(10)").IsRequired();
        }
    }
}
