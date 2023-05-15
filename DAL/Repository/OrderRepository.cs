using System.Collections.Generic;
using System.Linq;
using DAL.Interface;
using DAL.Models;

namespace DAL.Repository
{
    public class OrderRepository : Database, IReopsitory<Order, int, Order>
    {
        public Order Add(Order entity)
        {
            Context.Orders.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public Order Update(Order entity)
        {
            var order = GetById(entity.Id);
            if (order == null) return null;
            Context.Entry(order).CurrentValues.SetValues(entity);
            Context.SaveChanges();
            return entity;
        }

        public Order Delete(int id)
        {
            var order = GetById(id);
            if (order == null) return null;
            Context.Orders.Remove(order);
            Context.SaveChanges();
            return order;
        }

        public Order GetById(int id) => Context.Orders.FirstOrDefault(o => o.Id == id);

        public List<Order> GetAll() => Context.Orders.ToList();

        private static bool IsCustomerExist(int id) => DataAccessFactory.GetUserRepository().GetById(id) != null;
    }
}