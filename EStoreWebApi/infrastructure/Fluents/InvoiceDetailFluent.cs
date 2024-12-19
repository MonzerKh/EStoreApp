using EStoreWebApi.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EStoreWebApi.infrastructure.Fluents;

public class InvoiceDetailFluent : BaseFluent<InvoiceDetail>
{
    public override void Configure(EntityTypeBuilder<InvoiceDetail> builder)
    {
        base.Configure(builder);

        builder.Property(u => u.Discount).HasColumnType("decimal(18,2)");

        builder
         .HasOne(det => det.Invoice)
         .WithMany(mast => mast.InvoiceDetails)
         .HasForeignKey(mast => mast.InvoiceId)
         .OnDelete(DeleteBehavior.Cascade);
    }
}
