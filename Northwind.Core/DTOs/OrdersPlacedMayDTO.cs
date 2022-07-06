namespace Northwind.Core.DTOs
{
    public class OrdersPlacedMayDTO
    {
        public DateTime? OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string? CustomerId { get; set; }
        public decimal? Freight { get; set; }
    }
}
