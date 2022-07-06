using Northwind.API.Models;
using Northwind.Core.Interfaces;
using Northwind.Infrastructure.GenericRepository;

namespace Northwind.Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(NorthwindContext context): base(context)
        {

        }
    }
}
