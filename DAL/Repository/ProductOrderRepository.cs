using System.Collections.Generic;
using System.Linq;
using DAL.Interface;
using DAL.Models;

namespace DAL.Repository
{
    internal class ProductOrderRepository : Database, IReopsitory<ProductsOrder, int, bool>

    {
        public bool Add(ProductsOrder entity)
        {
            Context.ProductsOrders.Add(entity);
            return Context.SaveChanges() > 0;
        }

        public bool Update(ProductsOrder entity)
        {
            var productOrder = GetById(entity.Id);
            if (productOrder == null) return false;
            Context.Entry(productOrder).CurrentValues.SetValues(entity);
            return Context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var productOrder = GetById(id);
            if (productOrder == null) return false;
            Context.ProductsOrders.Remove(productOrder);
            return Context.SaveChanges() > 0;
        }

        public ProductsOrder GetById(int id) => Context.ProductsOrders.Find(id);

        public List<ProductsOrder> GetAll() => Context.ProductsOrders.ToList();
    }
}