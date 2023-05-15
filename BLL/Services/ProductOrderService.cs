using System.Collections.Generic;
using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;

namespace BLL.Services
{
    public static class ProductOrderService
    {
        public static List<ProductsOrderDto> GetAllProductsOrder()
        {
            var repository = DataAccessFactory.GetProductOrderRepository();
            var productsOrder = Mapper.Map(repository.GetAll(), new List<ProductsOrderDto>());
            return productsOrder;
        }

        public static ProductsOrderDto GetProductOrderById(int id)
        {
            var repository = DataAccessFactory.GetProductOrderRepository();
            var productOrder = Mapper.Map(repository.GetById(id), new ProductsOrderDto());
            return productOrder;
        }

        public static bool AddProductOrders(List<ProductsOrderDto> productOrders)
        {
            var repository = DataAccessFactory.GetProductOrderRepository();
            var ordersToAdd = Mapper.Map<List<ProductsOrderDto>, List<ProductsOrder>>(productOrders);

            foreach (var order in ordersToAdd)
            {
                repository.Add(order);
            }

            return true;
        }

        public static bool UpdateProductOrder(ProductsOrderDto productOrder)
        {
            var repository = DataAccessFactory.GetProductOrderRepository();
            var productOrderToUpdate = Mapper.Map(productOrder, new ProductsOrder());
            return repository.Update(productOrderToUpdate);
        }

        public static bool DeleteProductOrder(int id)
        {
            var repository = DataAccessFactory.GetProductOrderRepository();
            return repository.Delete(id);
        }

        public static List<ProductsOrderDto> GetProductsOrderForOrder(int orderId)
        {
            var repository = DataAccessFactory.GetProductOrderRepository();
            var productsOrder = Mapper.Map(repository.GetAll(), new List<ProductsOrderDto>());
            return productsOrder.FindAll(p => p.OrderId == orderId);
        }
    }
}