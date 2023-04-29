using DAL.Interface;
using DAL.Models;
using DAL.Repository;

namespace DAL
{
    public static class DataAccessFactory
    {
        // returns all repositories from DAL

        public static IReopsitory<User, int, bool> GetUserRepository() => new UserRepository();
        public static IReopsitory<Order, int, bool> GetOrderRepository() => new OrderRepository();
        public static IReopsitory<ProductsOrder, int, bool> GetProductOrderRepository() => new ProductOrderRepository();
        public static IReopsitory<DeliveryMan, int, bool> GetDeliveryManRepository() => new DeliveryManRepository();
        public static IReopsitory<DeliveryStatus, int, bool> GetDeliveryStatusRepository() => new DeliveryStatusRepository();
        public static IReopsitory<PaymentMethod, int, bool> GetPaymentMethodRepository() => new PaymentMethodRepository();
        public static IReopsitory<Company, int, bool> GetCompanyRepository() => new CompanyRepository();
        public static IReopsitory<Category, int, bool> GetCategoryRepository() => new CategoryRepository();
        public static IReopsitory<Product, int, bool> GetProductRepository() => new ProductRepository();
        public static IReopsitory<Profit, int, bool> GetProfitRepository() => new ProfitRepository();
        public static IReopsitory<AccountCashIn, int, bool> GetAccountCashInRepository() => new AccountCashInRepository();
        public static IReopsitory<AccountCashOut, int, bool> GetAccountCashOutRepository() => new AccountCashOutRepository();

    }
}