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
    public static class CategoryServices
    {
        public static bool AddCategory(CategoryDto category)
        {
            var categoryRepository = DataAccessFactory.GetCategoryRepository();
            var categoryToAdd = Mapper.Map(category, new Category());
            return categoryRepository.Add(categoryToAdd);
        }
        public static List<CategoryDto> GetAllCategory()
        {
            var categoryRepository = DataAccessFactory.GetCategoryRepository();
            var categories = Mapper.Map(categoryRepository.GetAll(), new List<CategoryDto>());
            return categories;
        }
        public static CategoryDto GetCategoryById(int id)
        {
            var categoryRepository = DataAccessFactory.GetCategoryRepository();
            var category = Mapper.Map(categoryRepository.GetById(id), new CategoryDto());
            return category;
        }
        public static bool UpdateCategory(CategoryDto category)
        {
            var categoryRepository = DataAccessFactory.GetCategoryRepository();
            var categoryToUpdate = Mapper.Map(category, new Category());
            return categoryRepository.Update(categoryToUpdate);
        }
        public static bool DeleteCategory(int id)
        {
            var categoryRepository = DataAccessFactory.GetCategoryRepository();
            return categoryRepository.Delete(id);
        }
    }
}
