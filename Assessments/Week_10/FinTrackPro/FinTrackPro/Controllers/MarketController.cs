using Microsoft.AspNetCore.Mvc;

namespace FinTrackPro.Controllers
{
    public class MarketController : Controller
    {
        public IActionResult Summary()
        {
            ViewBag.Status = "Market Open";

            ViewData["TopGainer"] = "Tesla";
            ViewData["Volume"] = 1500000;

            return View();
        }

        [HttpGet("Analyze/{ticker}/{days:int?}")]
        public IActionResult Analyze(string ticker, int? days)
        {
            if (days == null)
                days = 30;

            ViewBag.Ticker = ticker;
            ViewBag.Days = days;

            return View();
        }
    }
}
