using System.Collections.Generic;
using System.Linq;
using DAL.Interface;
using DAL.Models;

namespace DAL.Repository
{
    internal class AccountCashOutRepository : Database, IReopsitory<AccountCashOut, int, bool>
    {
        public bool Add(AccountCashOut entity)
        {
            Context.AccountCashOuts.Add(entity);
            return Context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var cashOut = GetById(id);
            if (cashOut == null) return false;
            Context.AccountCashOuts.Remove(cashOut);
            return Context.SaveChanges() > 0;
        }


        public AccountCashOut GetById(int id) => Context.AccountCashOuts.FirstOrDefault(u => u.Id == id);


        public List<AccountCashOut> GetAll() => Context.AccountCashOuts.ToList();


        public bool Update(AccountCashOut entity)
        {
            var cashOut = GetById(entity.Id);
            if (cashOut == null) return false;
            Context.Entry(cashOut).CurrentValues.SetValues(entity);
            return Context.SaveChanges() > 0;
        }
    }
}