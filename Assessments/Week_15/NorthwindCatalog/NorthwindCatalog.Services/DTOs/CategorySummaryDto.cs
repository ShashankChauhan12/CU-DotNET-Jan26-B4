namespace NorthwindCatalog.Services.DTOs
{
    public class CategorySummaryDto
    {
        public string CategoryName { get; set; } = null!;
        public int ProductCount { get; set; }
        public decimal AvgPrice { get; set; }
        public string MostExpensiveProduct { get; set; } = null!;
    }
}
