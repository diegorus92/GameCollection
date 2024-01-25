using GameCollectionAPI_BL.DTOs;
using GameCollectionAPI_BL.Services;
using GameCollectionAPI_DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameCollectionAPI_AL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpPost]
        public ActionResult<string> AddCategory(CategoryDTO category)
        {
            return Ok(_categoryService.AddCategory(category));
        }

        [HttpGet]
        public ActionResult<ICollection<CategoryResponseDTO>> GetCategories()
        {
            return  Ok(_categoryService.GetCategories());
        }
    }
}
