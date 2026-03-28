using CentralizedPricingEngine.Services;
using Microsoft.AspNetCore.Mvc;

namespace CentralizedPricingEngine.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IPricingService _pricingService;

        public ProductsController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }

        private static readonly List<Dictionary<string, object>> _products = new()
        {
            new() { ["Name"] = "Winter Jacket", ["BasePrice"] = 120.00m },
            new() { ["Name"] = "Scarf",         ["BasePrice"] = 25.00m  },
            new() { ["Name"] = "Boots",         ["BasePrice"] = 89.99m  },
            new() { ["Name"] = "Gloves",        ["BasePrice"] = 15.00m  },
            new() { ["Name"] = "Woolen Cap",    ["BasePrice"] = 12.50m  },
        };

        // GET
        public IActionResult Index()
        {
            ViewBag.Products = _products;
            ViewBag.Calculated = false;
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(List<string> selectedNames, string promoCode)
        {
            var cartItems = _products
                .Where(p => selectedNames.Contains(p["Name"].ToString()))
                .Select(p => new Dictionary<string, object>
                {
                    ["Name"] = p["Name"],
                    ["BasePrice"] = p["BasePrice"],
                }).ToList();

            decimal subtotal = cartItems.Sum(p => (decimal)p["BasePrice"]);
            decimal total = _pricingService.CalculatePrice(subtotal, promoCode);

            TempData["CartItems"] = System.Text.Json.JsonSerializer.Serialize(cartItems);
            TempData["PromoCode"] = promoCode;
            TempData["Subtotal"] = subtotal.ToString();
            TempData["Total"] = total.ToString();

            return RedirectToAction("Index", "Cart");
        }
    }
}