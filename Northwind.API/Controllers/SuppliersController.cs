using Microsoft.AspNetCore.Mvc;
using Northwind.Core.DTOs;
using Northwind.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Northwind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Provides suppliers operations")]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        /// <summary>
        /// Constructor Initialization
        /// </summary>
        /// <param name="supplierService"></param>
        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        /// <summary>
        /// Create a report that shows the CompanyName, Fax, Phone, Country, HomePage from the suppliers table sorted by the Country in descending order then by CompanyName in ascending order.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<SuppliersDTO>> GetAllSuppliers()
        {
            return await _supplierService.GetAllCompanySuppliers();
        }
    }
}
