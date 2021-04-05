using CashierManagement.Cashiers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashierManagementInfractureLayer.DatabaseContext.TypeConfigurators
{
    public class CashierTypeConfigurator : IEntityTypeConfiguration<Cashier>
    {
        public void Configure(EntityTypeBuilder<Cashier> builder)
        {
            builder.ToTable("Cashier", "dbo");
            builder.HasKey(ent => ent.Id);
            builder.Property(ent => ent.Guid).HasColumnName("Guid");
            builder.Property(ent => ent.Address).HasColumnName("Address")
                .HasConversion(ent => ent.ToString(), s => new IpAddress(s));
            builder.Property(ent => ent.StoredAmount).HasColumnName("StoredAmount");
            builder.Property(ent => ent.ModifiedAt).HasColumnName("ModifiedAt");
            builder.Property(ent => ent.CreatedAt).HasColumnName("CreatedAt");
        }
    }
}
