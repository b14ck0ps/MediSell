using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var CashOut = GetById(id);
            if (CashOut == null) return false;
            Context.AccountCashOuts.Remove(CashOut);
            return Context.SaveChanges() > 0;
        }


        public AccountCashOut GetById(int id) => Context.AccountCashOuts.FirstOrDefault(u => u.Id == id);


        public List<AccountCashOut> GetAll() => Context.AccountCashOuts.ToList();


        public bool Update(AccountCashOut entity)
        {
            var CashOut = GetById(entity.Id);
            if (CashOut == null) return false;
            Context.Entry(CashOut).CurrentValues.SetValues(entity);
            return Context.SaveChanges() > 0;
        }
    }
}
