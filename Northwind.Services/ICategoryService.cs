using Northwind.Core.DTOs;

namespace Northwind.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategoryNameAndDescription();
    }
}
