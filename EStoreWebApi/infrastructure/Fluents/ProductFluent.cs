using EStoreWebApi.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EStoreWebApi.infrastructure.Fluents;

public class ProductFluent : BaseFluent<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        base.Configure(builder);
        builder.Property(u => u.ProductionCountry).HasMaxLength(250);
        builder.Property(u => u.ProductName).HasMaxLength(250);
        builder.Property(u => u.BarcodeCode).HasMaxLength(200);
        builder.Property(u => u.Brand).HasMaxLength(200);
        builder.Property(u => u.ProductPrice).HasColumnType("decimal(18,2)");
    }
}
