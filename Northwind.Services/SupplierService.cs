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
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SuppliersDTO>> GetAllCompanySuppliers()
        {
            var suppliers = await _supplierRepository.GetAllAsync();

            var companySuppliers = from supplier in suppliers
                                   orderby supplier.Country descending 
                                   orderby supplier.CompanyName ascending
                                   select new Supplier
                                   {
                                       CompanyName = supplier.CompanyName,
                                       Phone = supplier.Phone,
                                       Fax = supplier.Fax,
                                       Country = supplier.Country,
                                       HomePage = supplier.HomePage,
                                   };

            var mapped = _mapper.Map<IEnumerable<SuppliersDTO>>(companySuppliers);

            return mapped;
        }
    }
}
