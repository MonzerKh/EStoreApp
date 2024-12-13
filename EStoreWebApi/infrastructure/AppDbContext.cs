using EStoreWebApi.AppCore.Entities;
using EStoreWebApi.infrastructure.Fluents;
using Microsoft.EntityFrameworkCore;

namespace EStoreWebApi.infrastructure
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        private static DbContextOptions<AppDbContext> GetOptions(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return optionsBuilder.Options;
        }


        public AppDbContext(string connectionString) : base(GetOptions(connectionString))
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        //public DbSet<Store> Stores { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductFluent());

            modelBuilder.Entity<ProductDetail>()
                .Property(u => u.Title).HasMaxLength(200);
            modelBuilder.Entity<ProductDetail>()
                .Property(u => u.DetailContent).HasMaxLength(250);

            modelBuilder.Entity<ProductDetail>()
                 .HasOne(det => det.Product)
                 .WithMany(mast => mast.ProductDetails)
                 .HasForeignKey(mast => mast.ProductId)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<InvoiceDetail>()
                 .HasOne(det => det.Invoice)
                 .WithMany(mast => mast.InvoiceDetails)
                 .HasForeignKey(mast => mast.InvoiceId)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.ApplyConfiguration(new InvoiceFluent());

      
            
            modelBuilder.Entity<InvoiceDetail>()
              .Property(u => u.ProductPrice).HasColumnType("decimal(18,2)");   
            modelBuilder.Entity<InvoiceDetail>()
              .Property(u => u.Discount).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Customer>()
                .Property(u => u.CustomerName).HasMaxLength(250);
            modelBuilder.Entity<Customer>()
                .Property(u => u.CustomerSorName).HasMaxLength(250);
            modelBuilder.Entity<Customer>()
                .Property(u => u.PhonNumber).HasMaxLength(250);
            modelBuilder.Entity<Customer>()
                .Property(u => u.Email).HasMaxLength(250);
        }

    }
}
