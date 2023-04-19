using System.Collections.Generic;
using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;

namespace BLL.Services
{
    public static class AccountCashInServices
    {
        public static List<AccountCashInDto> GetAllAccountCashIns()
        {
            var accountCashInRepository = DataAccessFactory.GetAccountCashInRepository();
            var cashIn = Mapper.Map(accountCashInRepository.GetAll(), new List<AccountCashInDto>());
            return cashIn;
        }

        public static AccountCashInDto GetAccountCashInById(int id)
        {
            var accountCashInRepository = DataAccessFactory.GetAccountCashInRepository();
            var cashIn = Mapper.Map(accountCashInRepository.GetById(id), new AccountCashInDto());
            return cashIn;
        }

        public static bool AddAccountCashIn(AccountCashInDto accountCashIn)
        {
            var accountCashInRepository = DataAccessFactory.GetAccountCashInRepository();
            var accountCashInToAdd = Mapper.Map(accountCashIn, new AccountCashIn());
            return accountCashInRepository.Add(accountCashInToAdd);
        }

        public static bool UpdateAccountCashIn(AccountCashInDto accountCashInDto)
        {
            var accountCashInRepository = DataAccessFactory.GetAccountCashInRepository();
            var accountCashInToUpdate = Mapper.Map(accountCashInDto, new AccountCashIn());
            return accountCashInRepository.Update(accountCashInToUpdate);
        }


        public static bool DeleteAccountCashIn(int id)
        {
            var accountCashInRepository = DataAccessFactory.GetAccountCashInRepository();
            return accountCashInRepository.Delete(id);
        }
    }
}