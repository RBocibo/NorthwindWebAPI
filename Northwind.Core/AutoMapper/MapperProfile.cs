using AutoMapper;
using Northwind.API.Models;
using Northwind.Core.DTOs;

namespace Northwind.Core.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<Order, OrdersDTO>();
            CreateMap<Customer, GetCustomerDTO>();
            CreateMap<Supplier, SuppliersDTO>();
            CreateMap<Customer, CustomersFromBuenosAiresDTO>();
            CreateMap<Product, GetProductOutOfStockDTO>();
            CreateMap<Customer, GetCustomerNotFromMexicoSpainGermanyDTO>();
            CreateMap<Order, OrdersPlacedMayDTO>();
        }
    }
}
