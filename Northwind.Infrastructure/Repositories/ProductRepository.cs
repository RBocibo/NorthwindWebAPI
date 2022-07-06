using Northwind.API.Models;
using Northwind.Core.Interfaces;
using Northwind.Infrastructure.GenericRepository;

namespace Northwind.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(NorthwindContext context) : base(context)
        {
        }
    }
}
