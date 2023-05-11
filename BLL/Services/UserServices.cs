using System.Collections.Generic;
using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;

namespace BLL.Services
{
    public static class UserServices
    {
        public static List<UserDto> GetAllUsers()
        {
            var userRepository = DataAccessFactory.GetUserRepository();
            var users = Mapper.Map(userRepository.GetAll(), new List<UserDto>());
            return users;
        }

        public static UserDto GetuserById(int id)
        {
            var userRepository = DataAccessFactory.GetUserRepository();
            var user = Mapper.Map(userRepository.GetById(id), new UserDto());
            return user;
        }

        public static bool Adduser(UserDto user)
        {
            var userRepository = DataAccessFactory.GetUserRepository();
            var userToAdd = Mapper.Map(user, new User());
            return userRepository.Add(userToAdd);
        }

        public static bool Updateuser(UserDto user)
        {
            var userRepository = DataAccessFactory.GetUserRepository();
            var userToUpdate = Mapper.Map(user, new User());
            return userRepository.Update(userToUpdate);
        }

        public static bool Deleteuser(int id)
        {
            var userRepository = DataAccessFactory.GetUserRepository();
            return userRepository.Delete(id);
        }

        public static UserDto GetUserByEmail(string email)
        {
            var userRepository = DataAccessFactory.GetUserRepository();
            return Mapper.Map(userRepository.GetByEmail(email), new UserDto());
        }
    }
}