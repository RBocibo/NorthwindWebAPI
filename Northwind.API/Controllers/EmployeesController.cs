using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Core.DTOs;
using Northwind.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Northwind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Provides employees operations")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Create a report that shows the capitalized FirstName and capitalized LastName renamed as FirstName and Lastname respectively and HireDate from the employees table sorted from the newest to the oldest employee.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<EmployeeDTO>> GetEmployeeSortByHireDate()
        {
            return await _employeeService.GetEmployeeFNameLNameSortByHireDate();
        }
    }
}
