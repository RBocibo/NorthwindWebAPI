namespace Northwind.Core.DTOs
{
    public class GetProductOutOfStockDTO
    {
        public string ProductName { get; set; } = null!;
        public string? QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
