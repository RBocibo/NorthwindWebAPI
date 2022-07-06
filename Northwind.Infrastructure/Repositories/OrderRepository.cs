using Northwind.API.Models;
using Northwind.Core.Interfaces;
using Northwind.Infrastructure.GenericRepository;

namespace Northwind.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(NorthwindContext context) : base(context)
        {
        }
    }
}
