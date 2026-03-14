using CorporatePulsePortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace CorporatePulsePortal.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Dashboard()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee { Id = 1, Name = "Rahul Sharma", Position = "Software Engineer", Salary = 60000 },
                new Employee { Id = 2, Name = "Ananya Gupta", Position = "UI Designer", Salary = 55000 },
                new Employee { Id = 3, Name = "Amit Verma", Position = "Project Manager", Salary = 80000 },
                new Employee { Id = 4, Name = "Sneha Kapoor", Position = "QA Tester", Salary = 50000 }
            };

            ViewBag.Announcement = "Team meeting today at 4 PM in Conference Room.";

            ViewData["DepartmentName"] = "Software Development";
            ViewData["ServerStatus"] = true;

            return View(employees);
        }
    }
}
