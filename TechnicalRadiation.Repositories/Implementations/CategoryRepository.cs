using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TechnicalRadiation.Models.Dtos;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories.Contexts;
using TechnicalRadiation.Services.Interfaces;

namespace TechnicalRadiation.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly NewsDbContext _newsDbContext;

        public CategoryRepository(NewsDbContext newsDbContext)
        {
            _newsDbContext = newsDbContext;
        }
        public CategoryDetailDto CreateCategory(CategoryInputModel category)
        {
            var slug = category.Name.ToLower();
            slug = Regex.Replace(slug, @"\s", "-");
            var newCatergory = new Category
            {
                Name = category.Name,
                Slug = slug
            };

            _newsDbContext.categories.Add(newCatergory);
            _newsDbContext.SaveChanges();

            return new CategoryDetailDto
            {
                Id = newCatergory.Id,
                Name = newCatergory.Name,
                Slug = newCatergory.Slug,
                NumberOfNewsItems = newCatergory.NewsItems.Count()
            };
            
        }

        public void DeleteCategoryById(int id)
        {
            var oneCategory = _newsDbContext
                .categories
                .Find(id);

            _newsDbContext.categories.Remove(oneCategory);
            
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var allCategories = _newsDbContext
                .categories
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Slug = c.Slug
                });
            return allCategories;
        }

        public CategoryDetailDto GetAllCategoriesById(int id)
        {
            var oneCategory = _newsDbContext
                .categories
                .Where(c => c.Id == id)
                .Select(C => new
                {
                    C.Id,
                    C.Name,
                    C.Slug,
                    C.NewsItems
                }).FirstOrDefault();

            return new CategoryDetailDto
            {
                Id = oneCategory.Id,
                Name = oneCategory.Name,
                Slug = oneCategory.Slug,
                NumberOfNewsItems = oneCategory.NewsItems.Count()
            };
            
        }

        public void UpdateCategoryById(CategoryInputModel category, int id)
        {
            var slug = category.Name.ToLower();
            slug = Regex.Replace(slug, @"\s", "-");

            var oneCategory = _newsDbContext
                .categories
                .Find(id);

            oneCategory.Name = category.Name;
            oneCategory.Slug = slug;
            
            _newsDbContext.SaveChanges();
        }
    }
}
