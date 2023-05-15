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

        public static int AddOrder(OrderDto order)
        {
            order.OderDate = System.DateTime.Now;

            var orderRepository = DataAccessFactory.GetOrderRepository();
            var orderToAdd = Mapper.Map(order, new Order());
            var newOrder = orderRepository.Add(orderToAdd);
            var user = UserServices.GetuserById(order.OrderedBy);
            //Send Email To Customer
            var html = $"" +
                       $"<h1>Order # {newOrder.Id} Placed Successfully</h1>" +
                       $"<h3> Order Date: {newOrder.OderDate}</h3>" +
                       $"<h3> Order Total: {newOrder.Total} Taka</h3>" +
                       $"For Detail visit: <a href='http://localhost:3000/order/{newOrder.Id}'>Click Here</a>";

            EmailService.SendEmail(fromAddress: MedicellEmail, toAddress: user.Email,
                subject: "Order Placed Successfully", htmlBody: html);

            return newOrder.Id;
        }

        public static bool UpdateOrder(OrderDto order)
        {
            var orderRepository = DataAccessFactory.GetOrderRepository();
            var orderToUpdate = Mapper.Map(order, new Order());
            orderRepository.Update(orderToUpdate);
            return true;
        }

        public static bool DeleteOrder(int id)
        {
            var orderRepository = DataAccessFactory.GetOrderRepository();
            orderRepository.Delete(id);
            return true;
        }

        private static bool IsCustomerExist(int id) => DataAccessFactory.GetUserRepository().GetById(id) != null;
        private const string MedicellEmail = "medicell@Real.org";
    }
}