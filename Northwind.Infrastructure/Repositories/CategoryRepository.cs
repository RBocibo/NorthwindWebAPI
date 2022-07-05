using Northwind.API.Models;
using Northwind.Core.Interfaces;
using Northwind.Infrastructure.GenericRepository;

namespace Northwind.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(NorthwindContext context) : base(context)
        {
        }
    }
}
