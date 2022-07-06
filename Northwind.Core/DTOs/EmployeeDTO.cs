namespace Northwind.Core.DTOs
{
    public class EmployeeDTO
    {
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public DateTime? HireDate { get; set; }
    }
}
