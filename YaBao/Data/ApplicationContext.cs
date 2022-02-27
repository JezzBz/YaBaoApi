using Microsoft.EntityFrameworkCore;
using YaBao.Models;

namespace YaBao.Data
{
    /// <summary>
    /// Main DataBase context
    /// </summary>
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// Based constructor
        /// </summary>
        /// <param name="options"></param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        /// <summary>
        /// one-to-many, many-to-many and other connection 
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one-to-many connection ProductType-Product
            modelBuilder.Entity<Product>()
                .HasOne<ProductType>()
                .WithMany()
                .HasForeignKey(k => k.ProductTypeId)
                .OnDelete(DeleteBehavior.SetNull);

            //many-to-many connection Stocks-Products  
            modelBuilder.Entity<Stock>()
                .HasMany(x => x.Products)
                .WithMany(x => x.Stocks);

            //one-to-one connection Slide-Stock
            modelBuilder.Entity<Stock>()
                .HasOne(x => x.Slide).WithOne(x => x.Stock).HasForeignKey<Slide>(x => x.StockId);


        }
        /// <summary>
        /// Product model
        /// </summary>
        public DbSet<Product> Products { get; set; }
        /// <summary>
        /// Product model
        /// </summary>
        public DbSet<ProductType> ProductTypes { get; set; }
        /// <summary>
        /// Stock model
        /// </summary>
        public DbSet<Stock> Stocks { get; set; }
        /// <summary>
        /// Slide model
        /// </summary>
        public DbSet<Slide> Slides { get; set; }

    }
}
