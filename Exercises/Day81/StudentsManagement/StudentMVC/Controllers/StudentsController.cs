using Microsoft.AspNetCore.Mvc;
using StudentMVC.Models;
using System.Text;
using System.Text.Json;


namespace StudentMVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IHttpClientFactory _factory;

        public StudentsController(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        // INDEX
        public async Task<IActionResult> Index()
        {
            var client = _factory.CreateClient("StudentAPI");

            var response = await client.GetAsync("api/students");

            if (!response.IsSuccessStatusCode)
                return View(new List<StudentViewModel>());

            var json = await response.Content.ReadAsStringAsync();

            var data = JsonSerializer.Deserialize<List<StudentViewModel>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return View(data);
        }

        // CREATE GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
        public async Task<IActionResult> Create(StudentViewModel model)
        {
            var client = _factory.CreateClient("StudentAPI");

            var json = JsonSerializer.Serialize(model);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            var response = await client.PostAsync(
                "api/students",
                content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(model);
        }

        // EDIT GET
        public async Task<IActionResult> Edit(int id)
        {
            var client = _factory.CreateClient("StudentAPI");

            var response = await client.GetAsync($"api/students/{id}");

            var json = await response.Content.ReadAsStringAsync();

            var student = JsonSerializer.Deserialize<StudentViewModel>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return View(student);
        }

        // EDIT POST
        [HttpPost]
        public async Task<IActionResult> Edit(StudentViewModel model)
        {
            var client = _factory.CreateClient("StudentAPI");

            var json = JsonSerializer.Serialize(model);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            var response = await client.PutAsync(
                $"api/students/{model.Id}",
                content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(model);
        }

        // DELETE GET
        public async Task<IActionResult> Delete(int id)
        {
            var client = _factory.CreateClient("StudentAPI");

            var response = await client.GetAsync($"api/students/{id}");

            var json = await response.Content.ReadAsStringAsync();

            var student = JsonSerializer.Deserialize<StudentViewModel>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return View(student);
        }

        // DELETE POST
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = _factory.CreateClient("StudentAPI");

            await client.DeleteAsync($"api/students/{id}");

            return RedirectToAction("Index");
        }
    }
}
