using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductServices
    {
        public static List<ProductDto> GetAllProduct()
        {
            var productRepository = DataAccessFactory.GetProductRepository();
            var products = productRepository.GetAll().Select(Mapper.Map<ProductDto>).ToList();
            return products;
        }
        public static bool AddProduct(ProductDto product)
        {
            var productRepository = DataAccessFactory.GetProductRepository();
            var productToAdd = Mapper.Map(product, new Product());
            return productRepository.Add(productToAdd);
        }
    }
}
