using EStoreWebApi.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EStoreWebApi.infrastructure.Fluents
{
    public class InvoiceDetailFluent : IEntityTypeConfiguration<InvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            builder
             .HasOne(det => det.Invoice)
             .WithMany(mast => mast.InvoiceDetails)
             .HasForeignKey(mast => mast.InvoiceId)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
