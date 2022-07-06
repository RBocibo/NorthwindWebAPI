using AutoMapper;
using Northwind.API.Models;
using Northwind.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomersFromBuenosAiresDTO>> GetAllCustomersFromBuenosAires()
        {
            var customers = await _customerRepository.GetAllAsync();

            var customer = from cus in customers
                           where cus.City == "Buenos Aires"
                           select new Customer
                           {
                               CompanyName = cus.CompanyName,
                               ContactName = cus.ContactName,
                           };

            var mapped = _mapper.Map<IEnumerable<CustomersFromBuenosAiresDTO>>(customer);

            return mapped;
        }

        public async Task<IEnumerable<GetCustomerNotFromMexicoSpainGermanyDTO>> GetAllCustomersNotFromGermanySpainMexico()
        {
            var customers = await _customerRepository.GetAllAsync();

            var customer = from cus in customers
                           where cus.Country != "Mexico" && cus.Country != "Spain" && cus.Country != "Germany"
                           select new Customer
                           {
                               ContactName = cus.ContactName,
                               Address = cus.Address,
                               City = cus.City,
                           };
            var mapped = _mapper.Map<IEnumerable<GetCustomerNotFromMexicoSpainGermanyDTO>>(customer);

            return mapped;
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomersSortByPhone()
        {
            var customers = await _customerRepository.GetAllAsync();

            var sortCustomers = from cus in customers
                                orderby cus.Phone
                                select new Customer
                                {
                                    CompanyName = cus.CompanyName,
                                    ContactName = cus.ContactName,
                                    ContactTitle = cus.ContactTitle,
                                    Phone = cus.Phone,
                                };
            var mappedCustomer = _mapper.Map<IEnumerable<CustomerDTO>>(sortCustomers);

            return mappedCustomer;
        }

        public async Task<IEnumerable<GetCustomerDTO>> ShowAllCustomerIdsInLowerCase()
        {
            var customers = await _customerRepository.GetAllAsync();

            var customerIds = from cus in customers
                              select new Customer
                              {
                                  CustomerId = cus.CustomerId.ToLower(),
                              };

            var mapped = _mapper.Map<IEnumerable<GetCustomerDTO>>(customerIds);

            return mapped;
        }
    }
}
