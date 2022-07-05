using Microsoft.AspNetCore.Mvc;
using Northwind.Core.DTOs;
using Northwind.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Northwind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [SwaggerTag("Provides operations to manage application version")]
    public class CategoriesController : ControllerBase
    {
        /// <summary>
        /// fields declaration
        /// </summary>
        private readonly ICategoryService _categoryService;

        /// <summary>
        /// Constructor initialization
        /// </summary>
        /// <param name="categoryService"></param>
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Create a report that shows the CategoryName and Description from the categories table sorted by CategoryName.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> GetCatNameAndDescription()
        {
            var result = await _categoryService.GetCategoryNameAndDescription();

            return result;
        }
    }
}
