using Northwind.Core.DTOs;

namespace Northwind.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrdersDTO>> GetTopTenOdersSortByFrieght();
        Task<IEnumerable<OrdersPlacedMayDTO>> GetAllOrderPlacedInMay();

    }
}
