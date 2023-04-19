using System.Collections.Generic;
using System.Linq;
using DAL.Interface;
using DAL.Models;

namespace DAL.Repository
{
    internal class AccountCashInRepository : Database, IReopsitory<AccountCashIn, int, bool>
    {
        public bool Add(AccountCashIn entity)
        {
            Context.AccountCashINs.Add(entity);
            return Context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var cashIn = GetById(id);
            if (cashIn == null) return false;
            Context.AccountCashINs.Remove(cashIn);
            return Context.SaveChanges() > 0;
        }


        public AccountCashIn GetById(int id) => Context.AccountCashINs.FirstOrDefault(u => u.Id == id);


        public List<AccountCashIn> GetAll() => Context.AccountCashINs.ToList();


        public bool Update(AccountCashIn entity)
        {
            var cashIn = GetById(entity.Id);
            if (cashIn == null) return false;
            Context.Entry(cashIn).CurrentValues.SetValues(entity);
            return Context.SaveChanges() > 0;
        }
    }
}