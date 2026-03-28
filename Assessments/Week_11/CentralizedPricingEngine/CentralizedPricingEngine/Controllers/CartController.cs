using CentralizedPricingEngine.Services;
using Microsoft.AspNetCore.Mvc;

namespace CentralizedPricingEngine.Controllers
{
    public class CartController : Controller
    {
        private readonly IPricingService _pricingService;

        public CartController(IPricingService pricingService)
        {
            _pricingService = pricingService;
        }

        public IActionResult Index()
        {
            if (TempData["CartItems"] == null)
                return RedirectToAction("Index", "Products");

            var json = TempData["CartItems"].ToString();
            var cartItems = System.Text.Json.JsonSerializer
                            .Deserialize<List<Dictionary<string, object>>>(json);

            ViewBag.CartItems = cartItems;
            ViewBag.PromoCode = TempData["PromoCode"];
            ViewBag.Subtotal = TempData["Subtotal"];
            ViewBag.GrandTotal = TempData["Total"];

            return View();
        }
    }
}