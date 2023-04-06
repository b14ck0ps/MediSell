using System.Data.Entity;
using DAL.Models;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=mssql_MediSell")
        {
        }

        internal DbSet<User> Users { get; set; }
        internal DbSet<Category> Categories { get; set; }
        internal DbSet<DeliveryMan> DeliveryMen { get; set; }
        internal DbSet<Product> Products { get; set; }
        internal DbSet<Order> Orders { get; set; }
        internal DbSet<DeliveryStatus> DeliveryStatuses { get; set; }
        internal DbSet<PaymentMethod> PaymentMethods { get; set; }
        internal DbSet<ProductsOrder> ProductsOrders { get; set; }
        internal DbSet<Company> Companies { get; set; }
        internal DbSet<AccountCashIn> AccountCashINs { get; set; }
        internal DbSet<AccountCashOut> AccountCashOuts { get; set; }
        internal DbSet<Profit> Profits { get; set; }
        internal DbSet<ProductsReview> ProductsReviews { get; set; }

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