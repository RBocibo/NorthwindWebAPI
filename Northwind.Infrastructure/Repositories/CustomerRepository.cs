using Northwind.API.Models;
using Northwind.Infrastructure;
using Northwind.Infrastructure.GenericRepository;

namespace Northwind.Services
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(NorthwindContext context) : base(context)
        {
        }
    }
}
