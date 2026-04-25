namespace LoanAPIUpdate.DTOs
{
    public class LoanDto
    {
        public int LoanId { get; set; }
        public int UserId { get; set; }
        public double Amount { get; set; }
        public string LoanType { get; set; } = string.Empty;
        public int TermInMonths { get; set; }
        public string Purpose { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public bool DocsVerified { get; set; }
        public double EMIAmount { get; set; }
        public double TotalPayable { get; set; }
    }
}
