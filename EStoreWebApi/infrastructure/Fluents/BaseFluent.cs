using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EStoreWebApi.infrastructure.Fluents;

public class BaseFluent<T> : IEntityTypeConfiguration<T> where T : class
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey("Id");

        builder.Property("CreatedDate").HasColumnType("datetime");
        builder.Property("UpdateDate").HasColumnType("datetime");
    }
}
