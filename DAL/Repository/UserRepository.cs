using System.Collections.Generic;
using System.Linq;
using DAL.Interface;
using DAL.Models;

namespace DAL.Repository
{
    public class UserRepository : Database, IAuth<bool>
    {
        public bool Authenticate(string email, string password)
        {
            var user = Context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            return user != null;
        }

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

        public User GetById(int id) => Context.Users.FirstOrDefault(u => u.Id == id);

        public List<User> GetAll() => Context.Users.ToList();
    }
}