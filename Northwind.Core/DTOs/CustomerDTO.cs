namespace Northwind.Core.DTOs
{
    public class CustomerDTO
    {
        public string CompanyName { get; set; } = null!;
        public string? ContactName { get; set; }
        public string? ContactTitle { get; set; }
        public string? Phone { get; set; }
    }
}
