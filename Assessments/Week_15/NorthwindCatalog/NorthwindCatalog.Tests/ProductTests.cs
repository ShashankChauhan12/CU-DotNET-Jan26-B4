using NorthwindCatalog.Services.DTOs;
using Xunit;

namespace NorthwindCatalog.Tests
{
    public class ProductTests
    {
        [Fact]
        public void InventoryValue_Should_Return_Correct_Value()
        {
            var product = new ProductDto
            {
                UnitPrice = 10,
                UnitsInStock = 5
            };

            Assert.Equal(50, product.InventoryValue);
        }
    }
}