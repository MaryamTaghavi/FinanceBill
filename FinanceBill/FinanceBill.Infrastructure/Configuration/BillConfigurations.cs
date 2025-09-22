using FinanceBill.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceBill.Infrastructure.Configuration;

public class BillConfigurations : IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        builder.HasOne(o => o.User)
                .WithOne(m => m.Bill)
                .HasForeignKey<Bill>(b => b.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
    }
}
