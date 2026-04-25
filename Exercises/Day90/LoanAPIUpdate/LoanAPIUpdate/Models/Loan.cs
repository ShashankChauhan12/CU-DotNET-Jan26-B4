namespace LoanAPIUpdate.Models
{
    public class Loan
    {
        public int LoanId { get; set; }
        public int UserId { get; set; }
        public double Amount { get; set; }
        public double InterestRate { get; set; }
        public string LoanType { get; set; } = string.Empty;
        public int TermInMonths { get; set; }
        public string Purpose { get; set; } = string.Empty;
        public string Status { get; set; } = "pending";
        public bool DocsVerified { get; set; } = false;
        public DateTime AppliedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public double EMIAmount { get; set; }
        public double TotalPayable { get; set; }
        public double TotalPaid { get; set; }

        public List<EMISchedule> EMISchedules { get; set; } = new();
    }
}
