using EStoreWebApi.AppCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EStoreWebApi.infrastructure
{
    public class AppDbContext : DbContext
    {
        #region config
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
        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(u=> u.ProductionCountry).HasMaxLength(250);
            modelBuilder.Entity<Product>()
                .Property(u=> u.ProductName).HasMaxLength(250);     
            modelBuilder.Entity<Product>()
                .Property(u=> u.BarcodeCode).HasMaxLength(200);  
            modelBuilder.Entity<Product>()
                .Property(u=> u.Brand).HasMaxLength(200);

            modelBuilder.Entity<ProductDetail>()
                .Property(u=> u.Title).HasMaxLength(200);
            modelBuilder.Entity<ProductDetail>()
                .Property(u=> u.DetailContent).HasMaxLength(250);
            modelBuilder.Entity<ProductDetail>()
                 .HasOne(det => det.Product)
                 .WithMany(mast => mast.ProductDetails)
                 .HasForeignKey(mast => mast.ProductId)
                 .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Product>().HasData(
            //    new Product() { Product_Name = "Test" },
            //    new Product() { Product_Name = "Test" });

            //modelBuilder.Entity<Product>().HasOne()
        }

}
