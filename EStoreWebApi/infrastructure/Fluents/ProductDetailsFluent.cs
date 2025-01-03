﻿using EStoreWebApi.AppCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EStoreWebApi.infrastructure.Fluents;

public class ProductDetailsFluent : BaseFluent<ProductDetail>
{
    public override void Configure(EntityTypeBuilder<ProductDetail> builder)
    {
        base.Configure(builder);

        builder.Property(u => u.Title).HasMaxLength(200);
        builder.Property(u => u.DetailContent).HasMaxLength(250);

        builder
              .HasOne(det => det.Product)
             .WithMany(mast => mast.ProductDetails)
             .HasForeignKey(mast => mast.ProductId)
             .OnDelete(DeleteBehavior.Cascade);
    }
}
