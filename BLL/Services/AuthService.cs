using System;
using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using DAL.Models.Enums;

namespace BLL.Services
{
    public static class AuthService
    {
        public static TokenDTO Authenticate(string email, string password)
        {
            var isValid = DataAccessFactory.GetUserRepository().Authenticate(email, password);
            if (!isValid) return null;
            var user = DataAccessFactory.GetUserRepository().GetByEmail(email);
            var token = new Token
            {
                TKey = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                UserId = user.Id
            };
            DataAccessFactory.GetTokenRepository().Add(token);
            return Mapper.Map(token, new TokenDTO());
        }

        private static bool IsTokenValid(string token)
        {
            var tokenRepository = DataAccessFactory.GetTokenRepository();
            var tokenObj = tokenRepository.GetById(token);
            if (tokenObj?.DeletedAt == null) return false;
            var user = DataAccessFactory.GetUserRepository().GetById(tokenObj.UserId);
            return user != null;
        }

        public static bool Logout(string token)
        {
            var tokenRepository = DataAccessFactory.GetTokenRepository();
            var tokenObj = tokenRepository.GetById(token);
            if (tokenObj == null) return false;
            tokenObj.DeletedAt = DateTime.Now;
            return tokenRepository.Update(tokenObj) != null;
        }

        private static User GetAuthUser(string token) => IsTokenValid(token)
            ? DataAccessFactory.GetUserRepository()
                .GetById(DataAccessFactory.GetTokenRepository().GetById(token).UserId)
            : null;

        public static bool IsAdmin(string token) => GetAuthUser(token)?.Role == Role.Admin;
        public static bool IsCustomer(string token) => GetAuthUser(token)?.Role == Role.Customer;
        public static bool IsDeliveryMan(string token) => GetAuthUser(token)?.Role == Role.Delivery;
        public static bool IsFinance(string token) => GetAuthUser(token)?.Role == Role.Finance;
    }
}