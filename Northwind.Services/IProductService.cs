using Northwind.Core.DTOs;

namespace Northwind.Services
{
    public interface IProductService
    {
        Task<IEnumerable<GetProductOutOfStockDTO>> GetAllProductsOutOfStock();
    }
}
