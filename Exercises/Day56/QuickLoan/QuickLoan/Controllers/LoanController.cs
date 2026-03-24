using Microsoft.AspNetCore.Mvc;
using QuickLoan.Models;

namespace QuickLoan.Controllers
{
    public class LoanController : Controller
    {
        private static List<Loan> loans = new List<Loan>()
        {
            new Loan{Id=1,BorrowerName="Sujal",LenderName="Bank",Amount=60000,IsSettled=false},
            new Loan{Id=2,BorrowerName="Ayush",LenderName="Finance Corp",Amount=7800,IsSettled=true},
        };
        public IActionResult Index()
        {
            return View(model: loans);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Loan loan)
        {
            if (ModelState.IsValid)
            {
                loan.Id = loans.Max(x => x.Id) + 1;
                loans.Add(loan);
                return RedirectToAction("Index");

            }
            return View(loan);

        }
        public IActionResult Edit(int id)
        {
            var loan = loans.FirstOrDefault(x => x.Id == id);
            return View(loan);
        }
        [HttpPost]
        public IActionResult Edit(Loan loan)
        {
            if (ModelState.IsValid)
            {
                var existing = loans.FirstOrDefault(x => x.Id == loan.Id);
                existing.BorrowerName = loan.BorrowerName;
                existing.LenderName = loan.LenderName;
                existing.Amount = loan.Amount;
                existing.IsSettled = loan.IsSettled;

                return RedirectToAction("Index");

            }

            return View(loan);
        }

        public IActionResult Delete(int id)
        {
            var loan = loans.FirstOrDefault(x => x.Id == id);
            loans.Remove(loan);
            return RedirectToAction("Index");
        }

    }
}
