namespace Northwind.Core.DTOs
{
    public class SuppliersDTO
    {
        public string CompanyName { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? Country { get; set; }
        public string? HomePage { get; set; }
    }
}
