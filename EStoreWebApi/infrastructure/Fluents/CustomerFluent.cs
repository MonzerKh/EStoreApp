using EStoreWebApi.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EStoreWebApi.infrastructure.Fluents
{
    public class CustomerFluent : BaseFluent<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.ProductPrice).HasColumnType("decimal(18,2)");
            builder.Property(u => u.CustomerName).HasMaxLength(250);
            builder.Property(u => u.CustomerSorName).HasMaxLength(250);
            builder.Property(u => u.PhonNumber).HasMaxLength(250);
            builder.Property(u => u.Email).HasMaxLength(250);
        }
    }
}
