namespace NorthwindCatalog.Services.DTOs
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
