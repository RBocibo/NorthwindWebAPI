using Microsoft.AspNetCore.Mvc;
using Northwind.Core.DTOs;
using Northwind.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Northwind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Provides operations to manage customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        /// <summary>
        /// Constructor initialization
        /// </summary>
        /// <param name="customerService"></param>
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Create a report that shows the ContactName, CompanyName, ContactTitle and Phone number from the customers table sorted by Phone.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<CustomerDTO>> GetCustomerSortPhone()
        {
            return await _customerService.GetAllCustomersSortByPhone();
        }

        /// <summary>
        /// Create a report that shows all the CustomerID in lowercase letter and renamed as ID from the customers table.
        /// </summary>
        /// <returns></returns>
        [HttpGet("CustomerIds")]
        public async Task<IEnumerable<GetCustomerDTO>> ShowAllcustomersId()
        {
            return await _customerService.ShowAllCustomerIdsInLowerCase();
        }
        /// <summary>
        /// Create a report that shows CompanyName, ContactName of all customers from ‘Buenos Aires' only.
        /// </summary>
        /// <returns></returns>
        [HttpGet("CustomersFromBeunosAires")]
        public async Task<IEnumerable<CustomersFromBuenosAiresDTO>> CustomersFromBuenosAires()
        {
            return await _customerService.GetAllCustomersFromBuenosAires();
        }

        /// <summary>
        /// Create a report showing all the ContactName, Address, City of all customers not from Germany, Mexico, Spain.
        /// </summary>
        /// <returns></returns>
        [HttpGet("NotFromMexico")]
        public async Task<IEnumerable<GetCustomerNotFromMexicoSpainGermanyDTO>> GetAllCustomersNotFromMexicoGermanySpain()
        {
            return await _customerService.GetAllCustomersNotFromGermanySpainMexico();
        }
    }
}
