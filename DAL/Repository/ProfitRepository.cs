using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    internal class ProfitRepository : Database, IReopsitory<Profit, int, bool>
    {
        public bool Add(Profit entity)
        {
            Context.Profits.Add(entity);
            return Context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var profit = GetById(id);
            if (profit == null) return false;
            Context.Profits.Remove(profit);
            return Context.SaveChanges() > 0;
        }


        public Profit GetById(int id) => Context.Profits.FirstOrDefault(u => u.Id == id);


        public List<Profit> GetAll() => Context.Profits.ToList();

        public bool Update(Profit entity)
        {
            var profit = GetById(entity.Id);
            if (profit == null) return false;
            Context.Entry(profit).CurrentValues.SetValues(entity);
            return Context.SaveChanges() > 0;
        }
    }
}
