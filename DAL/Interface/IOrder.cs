using System.Collections.Generic;
using DAL.Models;

namespace DAL.Interface
{
    public interface IOrder : IReopsitory<Order, int, bool>
    {
        List<Order> GetAllByCustomerId(int id);
        bool DeleteByCustomerId(int id);
    }
}