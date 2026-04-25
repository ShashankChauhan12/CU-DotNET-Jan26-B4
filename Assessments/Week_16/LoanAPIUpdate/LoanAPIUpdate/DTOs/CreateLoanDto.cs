namespace LoanAPIUpdate.DTOs
{
    public class CreateLoanDto
    {
        public int UserId { get; set; }
        public double Amount { get; set; }
        public string LoanType { get; set; } = string.Empty;
        public int TermInMonths { get; set; }
        public string Purpose { get; set; } = string.Empty;
    }
}
