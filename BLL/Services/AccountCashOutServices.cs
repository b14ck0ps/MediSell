using System.Collections.Generic;
using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;

namespace BLL.Services
{
    public static class AccountCashOutServices
    {
        public static List<AccountCashOutDto> GetAllAccountCashOuts()
        {
            var accountCashOutRepository = DataAccessFactory.GetAccountCashOutRepository();
            var cashOut = Mapper.Map(accountCashOutRepository.GetAll(), new List<AccountCashOutDto>());
            return cashOut;
        }

        public static AccountCashOutDto GetAccountCashOutById(int id)
        {
            var accountCashOutRepository = DataAccessFactory.GetAccountCashOutRepository();
            var cashOut = Mapper.Map(accountCashOutRepository.GetById(id), new AccountCashOutDto());
            return cashOut;
        }

        public static bool AddAccountCashOut(AccountCashOutDto accountCashOutDto)
        {
            var accountCashOutRepository = DataAccessFactory.GetAccountCashOutRepository();
            var accountCashOutToAdd = Mapper.Map(accountCashOutDto, new AccountCashOut());
            return accountCashOutRepository.Add(accountCashOutToAdd);
        }

        public static bool UpdateAccountCashOut(AccountCashOutDto accountCashOutDto)
        {
            var accountCashOutRepository = DataAccessFactory.GetAccountCashOutRepository();
            var accountCashOutToUpdate = Mapper.Map(accountCashOutDto, new AccountCashOut());
            return accountCashOutRepository.Update(accountCashOutToUpdate);
        }


        public static bool DeleteAccountCashOut(int id)
        {
            var accountCashOutRepository = DataAccessFactory.GetAccountCashOutRepository();
            return accountCashOutRepository.Delete(id);
        }
    }
}