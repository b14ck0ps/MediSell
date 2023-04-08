using System.Collections.Generic;
using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;

namespace BLL.Services
{
    public static class UserServices
    {
        public static List<UserDto> GetAllCustomers()
        {
            var customerRepository = DataAccessFactory.GetCustomerRepository();
            var customers = Mapper.Map(customerRepository.GetAll(), new List<UserDto>());
            return customers;
        }

        public static UserDto GetCustomerById(int id)
        {
            var customerRepository = DataAccessFactory.GetCustomerRepository();
            var customer = Mapper.Map(customerRepository.GetById(id), new UserDto());
            return customer;
        }

        public static bool AddCustomer(UserDto customer)
        {
            var customerRepository = DataAccessFactory.GetCustomerRepository();
            var customerToAdd = Mapper.Map(customer, new User());
            return customerRepository.Add(customerToAdd);
        }

        public static bool UpdateCustomer(UserDto customer)
        {
            var customerRepository = DataAccessFactory.GetCustomerRepository();
            var customerToUpdate = Mapper.Map(customer, new User());
            return customerRepository.Update(customerToUpdate);
        }

        public static bool DeleteCustomer(int id)
        {
            var customerRepository = DataAccessFactory.GetCustomerRepository();
            return customerRepository.Delete(id);
        }
    }
}