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
        public static List<ProductDto> GetAllProducts()
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
        public static ProductDto GetProductById(int id)
        {
            var productRepository = DataAccessFactory.GetProductRepository();
            var product = Mapper.Map(productRepository.GetById(id), new ProductDto());
            return product;
        }
        public static List<ProductDto> GetAllProductsByCompanyId(int id)
        {
            var productRepository = DataAccessFactory.GetProductRepository();
            var products = productRepository.GetAll();
            var productsByCompanyId = products.Where(C => C.CompanyId == id).Select(Mapper.Map<ProductDto>).ToList();
            return productsByCompanyId;
        }
        public static List<ProductDto> GetAllProductsByCategoryId(int id)
        {
            var productRepository = DataAccessFactory.GetProductRepository();
            var products = productRepository.GetAll();
            var productsByCompanyId = products.Where(c => c.CategoryId == id).Select(Mapper.Map<ProductDto>).ToList();
            return productsByCompanyId;
        }
        public static bool UpdateProduct(ProductDto product)
        {
            var productRepository = DataAccessFactory.GetProductRepository();
            var productToUpdate = Mapper.Map(product, new Product());
            return productRepository.Update(productToUpdate);
        }
        public static bool DeleteProduct(int id)
        {
            var productRepository = DataAccessFactory.GetProductRepository();
            return productRepository.Delete(id);
        }
    }
}
