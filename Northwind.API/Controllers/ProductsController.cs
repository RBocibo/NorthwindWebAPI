using Microsoft.AspNetCore.Mvc;
using Northwind.Core.DTOs;
using Northwind.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Northwind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Provides all the products operations")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        /// <summary>
        /// Constructor initialization
        /// </summary>
        /// <param name="productService"></param>
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Create a report showing ProductName, UnitPrice, QuantityPerUnit of products that are out of stock.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<GetProductOutOfStockDTO>> GetAllProductsNotInStock()
        {
            return await _productService.GetAllProductsOutOfStock();
        }
    }
}
