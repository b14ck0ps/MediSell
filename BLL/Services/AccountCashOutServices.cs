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
    public static class AccountCashOutServices
    {
        public static List<AccountCashOutDto> GetAllAccountCashOuts()
        {
            var AccountCashOutRepository = DataAccessFactory.GetAccountCashOutRepository();
            var CashOut = Mapper.Map(AccountCashOutRepository.GetAll(), new List<AccountCashOutDto>());
            return CashOut;
        }

        public static AccountCashOutDto GetAccountCashOutById(int id)
        {
            var AccountCashOutRepository = DataAccessFactory.GetAccountCashOutRepository();
            var CashOut = Mapper.Map(AccountCashOutRepository.GetById(id), new AccountCashOutDto());
            return CashOut;
        }

        public static bool AddAccountCashOut(AccountCashOutDto AccountCashOut)
        {
            var AccountCashOutRepository = DataAccessFactory.GetAccountCashOutRepository();
            var AccountCashOutToAdd = Mapper.Map(AccountCashOut, new AccountCashOut());
            return AccountCashOutRepository.Add(AccountCashOutToAdd);
        }

        public static bool UpdateAccountCashOut(AccountCashOutDto AccountCashOut)
        {
            var AccountCashOutRepository = DataAccessFactory.GetAccountCashOutRepository();
            var AccountCashOutToUpdate = Mapper.Map(AccountCashOut, new AccountCashOut());
            return AccountCashOutRepository.Update(AccountCashOutToUpdate);
        }


        public static bool DeleteAccountCashOut(int id)
        {
            var AccountCashOutRepository = DataAccessFactory.GetAccountCashOutRepository();
            return AccountCashOutRepository.Delete(id);
        }


    }
}
