using EStoreWebApi.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EStoreWebApi.infrastructure.Fluents;

public class InvoiceFluent : BaseFluent<Invoice>
{
    public override void Configure(EntityTypeBuilder<Invoice> builder)
    {
        base.Configure(builder);

        builder.Property(u => u.InvoiceDate).HasColumnType("datetime");
        builder.Property(u => u.InvoiceTotal).HasColumnType("decimal(18,2)");


        builder
        .HasOne(det => det.Customer)
        .WithMany(mast => mast.Invoices)
        .HasForeignKey(mast => mast.CustomerId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}
