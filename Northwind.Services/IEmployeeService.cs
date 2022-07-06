using Northwind.Core.DTOs;

namespace Northwind.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetEmployeeFNameLNameSortByHireDate();
    }
}
