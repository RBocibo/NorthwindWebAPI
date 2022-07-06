using Northwind.API.Models;
using Northwind.Core.GenericInterface;

namespace Northwind.Services
{
    public interface ICustomerRepository : IRepository<Customer>
    {
    }
}
