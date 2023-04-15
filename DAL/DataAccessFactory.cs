using DAL.Interface;
using DAL.Models;
using DAL.Repository;

namespace DAL
{
    public static class DataAccessFactory
    {
        // returns all repositories from DAL
        public static IReopsitory<User, int, bool> GetUserRepository() => new UserRepository();

        public static IOrder GetOrderRepository() => new OrderRepository();
    }
}