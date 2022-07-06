using Northwind.Core.DTOs;

namespace Northwind.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDTO>> GetAllCustomersSortByPhone();
        Task<IEnumerable<GetCustomerDTO>> ShowAllCustomerIdsInLowerCase();
        Task<IEnumerable<CustomersFromBuenosAiresDTO>> GetAllCustomersFromBuenosAires();
        Task<IEnumerable<GetCustomerNotFromMexicoSpainGermanyDTO>> GetAllCustomersNotFromGermanySpainMexico();
    }
}
