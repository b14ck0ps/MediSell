﻿using System.Collections.Generic;
using System.Linq;
using DAL.Interface;
using DAL.Models;
using DAL.Models.Enums;

namespace DAL.Repository
{
    public class CustomerRepository : Database, IReopsitory<User, int, bool>
    {
        public bool Add(User entity)
        {
            Context.Users.Add(entity);
            return Context.SaveChanges() > 0;
        }

        public bool Update(User entity)
        {
            var customer = GetById(entity.Id);
            if (customer == null) return false;
            Context.Entry(customer).CurrentValues.SetValues(entity);
            return Context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var customer = GetById(id);
            if (customer == null) return false;
            Context.Users.Remove(customer);
            return Context.SaveChanges() > 0;
        }

        public User GetById(int id)
        {
            return Context.Users.FirstOrDefault(u => u.Id == id && u.Role == Role.Customer);
        }

        public List<User> GetAll()
        {
            return Context.Users.Where(u => u.Role == Role.Customer).ToList();
        }
    }
}