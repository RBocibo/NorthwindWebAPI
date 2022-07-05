using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.API.Models;
using Northwind.Core.DTOs;
using Northwind.Services;

namespace Northwind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> GetCatNameAndDescription()
        {
            var result = await _categoryService.GetCategoryNameAndDescription();

            return result;
        }
    }
}
