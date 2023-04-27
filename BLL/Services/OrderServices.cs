using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;

namespace BLL.Services
{
    public class OrderServices
    {
        public static List<OrderDto> GetAllOrders()
        {
            var orderRepository = DataAccessFactory.GetOrderRepository();
            var orders = orderRepository.GetAll().Select(Mapper.Map<OrderDto>).ToList();
            return orders;
        }


        public static OrderDto GetOrderById(int id)
        {
            var orderRepository = DataAccessFactory.GetOrderRepository();
            var order = Mapper.Map(orderRepository.GetById(id), new OrderDto());
            return order;
        }

        public static List<OrderDto> GetAllOrdersByCustomerId(int id)
        {
            var orderRepository = DataAccessFactory.GetOrderRepository();
            var orders = orderRepository.GetAll();
            var ordersByCustomerId = orders.Where(o => o.OrderedBy == id).Select(Mapper.Map<OrderDto>).ToList();
            return ordersByCustomerId;
        }

        public static bool AddOrder(OrderDto order)
        {
            order.OderDate = System.DateTime.Now;

            var orderRepository = DataAccessFactory.GetOrderRepository();
            var orderToAdd = Mapper.Map(order, new Order());
            return orderRepository.Add(orderToAdd);
        }

        public static bool UpdateOrder(OrderDto order)
        {
            var orderRepository = DataAccessFactory.GetOrderRepository();
            var orderToUpdate = Mapper.Map(order, new Order());
            return orderRepository.Update(orderToUpdate);
        }

        public static bool DeleteOrder(int id)
        {
            var orderRepository = DataAccessFactory.GetOrderRepository();
            return orderRepository.Delete(id);
        }

        private static bool IsCustomerExist(int id) => DataAccessFactory.GetUserRepository().GetById(id) != null;
    }
}