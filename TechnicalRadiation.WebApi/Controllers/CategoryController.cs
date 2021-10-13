using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Services.Interfaces;

namespace TechnicalRadiation.WebApi.Controllers
{
    [ApiController]
    [Route("/api/categories")]
    public class CategoryController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllCategories()
        {
            return Ok(_categoryService.GetAllCategories());
        }

        [HttpGet]
        [Route("{categoryId: int}", Name= "GetAllCategoriesById")]
        public IActionResult GetAllCategoriesById(int categoryId)
        {
            return Ok(_categoryService.GetAllCategoriesById(categoryId));
        }
        [HttpPost]
        [Route("")]
        public IActionResult CreateCategory([FromBody] CategoryInputModel category)
        {
            var createdCategory = _categoryService.CreateCategory(category);
            return CreatedAtRoute("GetAllCategoriesById", new { categoryId  = createdCategory.Id}, createdCategory);
        }

        [HttpPut]
        [Route("{categoryId: int}")]
        public IActionResult UpdateCategoryById([FromBody] CategoryInputModel category, int categoryId)
        {
            _categoryService.UpdateCategoryById(category, categoryId);
            return NoContent();
        }
        [HttpDelete]
        [Route("{categoryId: int}")]
        public IActionResult DeleteCategoryById(int categoryId)
        {
            _categoryService.DeleteCategoryById(categoryId);
            return NoContent();
        }
        
    }
}
