namespace Northwind.Core.DTOs
{
    public class OrdersDTO
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string? CustomerId { get; set; }
        public decimal? Freight { get; set; }
    }
}
