using AutoMapper;
using Northwind.API.Models;
using Northwind.Core.DTOs;
using Northwind.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Northwind.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployeeFNameLNameSortByHireDate()
        {
            var employees = await _employeeRepository.GetAllAsync();

            var selectEmployee = from emp in employees
                                 orderby emp.HireDate descending
                                 select new Employee
                                 {
                                     FirstName = emp.FirstName,
                                     LastName = emp.LastName,
                                     HireDate = emp.HireDate,
                                 };

            var mapped = _mapper.Map<IEnumerable<EmployeeDTO>>(selectEmployee);

            return mapped;
        }
    }
}
