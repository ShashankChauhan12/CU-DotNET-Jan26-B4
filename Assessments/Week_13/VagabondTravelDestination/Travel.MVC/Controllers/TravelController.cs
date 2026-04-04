using Microsoft.AspNetCore.Mvc;
using Travel.MVC.Services;

namespace Travel.MVC.Controllers
{
    public class TravelController : Controller
    {
        private readonly IDestinationService _service;

        public TravelController(IDestinationService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

    }
}
