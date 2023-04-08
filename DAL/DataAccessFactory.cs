using DAL.Models;
using DAL.Repository;
using DAL.Interface;

namespace DAL
{
    public static class DataAccessFactory
    {
        // returns all repositories from DAL
        public static IReopsitory<User, int, bool> GetUserRepository()
        {
            return new UserRepository();
        }
        public static IOrder GetOrderRepository()
        {
            return new OrderRepository();
        }
    }
}