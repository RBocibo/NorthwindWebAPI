using Microsoft.AspNetCore.Mvc;
using Northwind.Core.DTOs;
using Northwind.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace Northwind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Provides orders operations")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        /// <summary>
        /// Constructor Initialization
        /// </summary>
        /// <param name="orderService"></param>
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        /// <summary>
        /// Create a report that shows the top 10 OrderID, OrderDate, ShippedDate, CustomerID, Freight from the orders table sorted by Freight in descending order.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<OrdersDTO>> GetOrdersOrderByFrieght()
        {
            return await _orderService.GetTopTenOdersSortByFrieght();
        }

        /// <summary>
        /// Create a report showing OrderDate, ShippedDate, CustomerID, Freight of all orders placed on 21 May 1996.
        /// </summary>
        /// <returns></returns>
        [HttpGet("DateForMay")]
        public async Task<IEnumerable<OrdersPlacedMayDTO>> GetAllOrdersForMaydate()
        {
            return await _orderService.GetAllOrderPlacedInMay();
        }
    }
}
