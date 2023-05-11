using System.Data.Entity;
using DAL.Models;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=mssql_MediSell")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DeliveryMan> DeliveryMen { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DeliveryStatus> DeliveryStatuses { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<ProductsOrder> ProductsOrders { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<AccountCashIn> AccountCashINs { get; set; }
        public DbSet<AccountCashOut> AccountCashOuts { get; set; }
        public DbSet<Profit> Profits { get; set; }
        public DbSet<ProductsReview> ProductsReviews { get; set; }
        public DbSet<Token> Tokens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Product One to Many with Category And Cascade Delete off
            modelBuilder.Entity<Product>()
                .HasRequired(c => c.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(c => c.CategoryId)
                .WillCascadeOnDelete(false);
            //Order One to Many with User And Cascade Delete off
            modelBuilder.Entity<Order>()
                .HasRequired(c => c.User)
                .WithMany(p => p.Orders)
                .HasForeignKey(c => c.OrderedBy)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}