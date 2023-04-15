﻿using System.Collections.Generic;
using System.Linq;
using DAL.Interface;
using DAL.Models;

namespace DAL.Repository
{
    public class OrderRepository : Database, IReopsitory<Order, int, bool>
    {
        public bool Add(Order entity)
        {
            Context.Orders.Add(entity);
            return Context.SaveChanges() > 0;
        }

        public bool Update(Order entity)
        {
            var order = GetById(entity.Id);
            if (order == null) return false;
            Context.Entry(order).CurrentValues.SetValues(entity);
            return Context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var order = GetById(id);
            if (order == null) return false;
            Context.Orders.Remove(order);
            return Context.SaveChanges() > 0;
        }

        public Order GetById(int id) => Context.Orders.FirstOrDefault(o => o.Id == id);

        public List<Order> GetAll() => Context.Orders.ToList();

        private static bool IsCustomerExist(int id) => DataAccessFactory.GetUserRepository().GetById(id) != null;
    }
}