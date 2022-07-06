using Northwind.API.Models;
using Northwind.Core.Interfaces;
using Northwind.Infrastructure.GenericRepository;

namespace Northwind.Infrastructure.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(NorthwindContext context) : base(context)
        {
        }
    }
}
