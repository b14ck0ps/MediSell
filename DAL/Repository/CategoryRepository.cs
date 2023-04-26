using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    internal class CategoryRepository : Database, IReopsitory<Category, int, bool>
    {
        public bool Add(Category entity)
        {
            Context.Categories.Add(entity);
            return Context.SaveChanges() > 0;
        }

        public List<Category> GetAll() => Context.Categories.ToList();

        public Category GetById(int id) => Context.Categories.FirstOrDefault(u => u.Id == id);

        public bool Update(Category entity)
        {
            var category = GetById(entity.Id);
            if (category == null) return false;
            Context.Entry(category).CurrentValues.SetValues(entity);
            return Context.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var category = GetById(id);
            if (category == null) return false;
            Context.Categories.Remove(category);
            return Context.SaveChanges() > 0;
        }
    }
}
