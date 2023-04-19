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
        public static IReopsitory<Company, int, bool> GetCompanyRepository() => new CompanyRepository();
        public static IReopsitory<Category, int, bool> GetCategoryRepository() => new CategoryRepository();

    }
}