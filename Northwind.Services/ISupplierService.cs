using Northwind.Core.DTOs;

namespace Northwind.Services
{
    public interface ISupplierService
    {
        Task<IEnumerable<SuppliersDTO>> GetAllCompanySuppliers();
    }
}
