using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FinTrackPro.Models
{
    public class Account
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }

        [ValidateNever]
        public List<Transaction> Transactions { get; set; }
    }
}
