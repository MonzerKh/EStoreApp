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
            
            modelBuilder.ApplyConfiguration(new InvoiceFluent());
            modelBuilder.ApplyConfiguration(new CustomerFluent());
            modelBuilder.ApplyConfiguration(new ProductDetailsFluent());
            modelBuilder.ApplyConfiguration(new InvoiceDetailFluent()); 
        }

    }
}
