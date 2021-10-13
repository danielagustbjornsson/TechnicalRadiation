using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Services.Interfaces;

namespace TechnicalRadiation.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoriesRepository;

        public CategoryService(ICategoryRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public CategoryDetailDto CreateCategory(CategoryInputModel category)
        {
            return _categoriesRepository.CreateCategory(category);
        }

        public void DeleteCategoryById(int id)
        {
            _categoriesRepository.DeleteCategoryById(id);
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            return _categoriesRepository.GetAllCategories();
        }

        public CategoryDetailDto GetAllCategoriesById(int id)
        {
            return _categoriesRepository.GetAllCategoriesById(id);
        }


        public void UpdateCategoryById(CategoryInputModel category, int id)
        {
            _categoriesRepository.UpdateCategoryById(category, id);
        }
    }
}
