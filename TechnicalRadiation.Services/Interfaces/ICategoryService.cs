using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetAllCategories();
        CategoryDetailDto GetAllCategoriesById(int id);
        CategoryDetailDto CreateCategory(CategoryInputModel category);
        void UpdateCategoryById(CategoryInputModel category, int id);
        void DeleteCategoryById(int id);
        

    }
}
