using System.Data.Entity;
using DAL.Models;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=mssql_MediSell")
        {
        }

        private DbSet<User> Users { get; set; }
        private DbSet<Category> Categories { get; set; }
        private DbSet<DeliveryMan> DeliveryMen { get; set; }
        private DbSet<Product> Products { get; set; }
        private DbSet<Order> Orders { get; set; }
        private DbSet<DeliveryStatus> DeliveryStatuses { get; set; }
        private DbSet<PaymentMethod> PaymentMethods { get; set; }
        private DbSet<ProductsOrder> ProductsOrders { get; set; }
        private DbSet<Company> Companies { get; set; }
        private DbSet<AccountCashIn> AccountCashINs { get; set; }
        private DbSet<AccountCashOut> AccountCashOuts { get; set; }
        private DbSet<Profit> Profits { get; set; }
        private DbSet<ProductsReview> ProductsReviews { get; set; }

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