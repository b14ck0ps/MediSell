using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    internal class ProductRepository : Database, IReopsitory<Product, int, bool>
    {
        public bool Add(Product entity)
        {
            Context.Products.Add(entity);
            return Context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var product = GetById(id);
            if (product == null) return false;
            Context.Products.Remove(product);
            return Context.SaveChanges() > 0;
        }

        public List<Product> GetAll() => Context.Products.ToList();

        public Product GetById(int id) => Context.Products.FirstOrDefault(p => p.Id == id);

        public bool Update(Product entity)
        {
            var product = GetById(entity.Id);
            if (product == null) return false;
            Context.Entry(product).CurrentValues.SetValues(entity);
            return Context.SaveChanges() > 0;
        }
    }
}
