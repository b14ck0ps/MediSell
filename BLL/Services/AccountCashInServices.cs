using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public static class AccountCashInServices
    {
        public static List<AccountCashInDto> GetAllAccountCashIns()
        {
            var AccountCashInRepository = DataAccessFactory.GetAccountCashInRepository();
            var CashIn = Mapper.Map(AccountCashInRepository.GetAll(), new List<AccountCashInDto> ());
            return CashIn;
        }

        public static AccountCashInDto GetAccountCashInById(int id)
        {
            var AccountCashInRepository = DataAccessFactory.GetAccountCashInRepository();
            var CashIn = Mapper.Map(AccountCashInRepository.GetById(id), new AccountCashInDto());
            return CashIn;
        }

        public static bool AddAccountCashIn(AccountCashInDto AccountCashIn)
        {
            var AccountCashInRepository = DataAccessFactory.GetAccountCashInRepository();
            var AccountCashInToAdd = Mapper.Map(AccountCashIn, new AccountCashIn());
            return AccountCashInRepository.Add(AccountCashInToAdd);
        }

        public static bool UpdateAccountCashIn(AccountCashInDto AccountCashIn)
        {
            var AccountCashInRepository = DataAccessFactory.GetAccountCashInRepository();
            var AccountCashInToUpdate = Mapper.Map(AccountCashIn, new AccountCashIn());
            return AccountCashInRepository.Update(AccountCashInToUpdate);
        }


        public static bool DeleteAccountCashIn(int id)
        {
            var AccountCashInRepository = DataAccessFactory.GetAccountCashInRepository();
            return AccountCashInRepository.Delete(id);
        }
    }
}
