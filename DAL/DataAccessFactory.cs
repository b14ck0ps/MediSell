using DAL.Models;
using DAL.Repository;
using DAL.Interface;
using System.Collections.Generic;

namespace DAL
{
    public static class DataAccessFactory
    {
        // returns all repositories from DAL
        public static IReopsitory<User, int, bool> GetCustomerRepository()
        {
            return new CustomerRepository();
        }
    }
}