using AutoMapper;
using Northwind.API.Models;
using Northwind.Core.DTOs;
using Northwind.Core.Interfaces;

namespace Northwind.Services
{
    public class CategoriesService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoriesService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoryNameAndDescription()
        {
            var category = await _categoryRepository.GetAllAsync();

            var result = from cat in category
                         orderby cat.CategoryName
                         select new Category
                         {
                             CategoryName = cat.CategoryName,
                             Description = cat.Description,
                         };

            var mappedCategory =  _mapper.Map<IEnumerable<CategoryDTO>>(result);

            return mappedCategory;
        }
    }
}
