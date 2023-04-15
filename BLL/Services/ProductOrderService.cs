using System.Collections.Generic;
using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;

namespace BLL.Services
{
    public class ProductOrderService
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

        public static bool AddProductOrder(ProductsOrderDto productOrder)
        {
            var repository = DataAccessFactory.GetProductOrderRepository();
            var productOrderToAdd = Mapper.Map(productOrder, new ProductsOrder());
            return repository.Add(productOrderToAdd);
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