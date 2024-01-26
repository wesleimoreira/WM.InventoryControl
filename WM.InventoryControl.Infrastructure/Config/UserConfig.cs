using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WM.InventoryControl.Domain.Entities;

namespace WM.InventoryControl.Infrastructure.Config
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(x => x.Password).HasColumnType("nvarchar(max)").IsRequired();


            // EF
            builder
                .HasOne(x => x.Employee)
                .WithOne()
                .HasForeignKey<User>(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
