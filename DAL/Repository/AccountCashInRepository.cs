using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var CashIn = GetById(id);
            if (CashIn == null) return false;
            Context.AccountCashINs.Remove(CashIn);
            return Context.SaveChanges() > 0;
        }


        public AccountCashIn GetById(int id) => Context.AccountCashINs.FirstOrDefault(u => u.Id == id);


        public List<AccountCashIn> GetAll() => Context.AccountCashINs.ToList();


        public bool Update(AccountCashIn entity)
        {
            var CashIn = GetById(entity.Id);
            if (CashIn == null) return false;
            Context.Entry(CashIn).CurrentValues.SetValues(entity);
            return Context.SaveChanges() > 0;
        }

    }
}
