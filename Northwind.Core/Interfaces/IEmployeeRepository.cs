using Northwind.API.Models;
using Northwind.Core.GenericInterface;

namespace Northwind.Core.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
    }
}
