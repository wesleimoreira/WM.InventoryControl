using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WM.InventoryControl.Domain.Entities;

namespace WM.InventoryControl.Infrastructure.Config
{
    public class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("nvarchar(150)").IsRequired();

            // EF
            builder
                .HasMany(x => x.Employees)
                .WithOne(x => x.Company)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Address)
                .WithOne(x => x.Company)
                .HasForeignKey<Company>(x => x.AddressId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
