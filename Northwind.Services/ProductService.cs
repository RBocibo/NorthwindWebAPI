using AutoMapper;
using Northwind.API.Models;
using Northwind.Core.DTOs;
using Northwind.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetProductOutOfStockDTO>> GetAllProductsOutOfStock()
        {
            var products = await _productRepository.GetAllAsync();

            var productsOutOfStock = from prod in products
                                     where prod.UnitsInStock == 0
                                     select new Product()
                                     {
                                         ProductName = prod.ProductName,
                                         UnitPrice = prod.UnitPrice,
                                         QuantityPerUnit = prod.QuantityPerUnit,
                                     };

            var mapped = _mapper.Map<IEnumerable<GetProductOutOfStockDTO>>(productsOutOfStock); 

            return mapped;
        }
    }
}
