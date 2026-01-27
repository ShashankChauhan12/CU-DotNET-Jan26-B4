using System;

namespace LoanSystem
{
    class Loan
    {
        public string LoanNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal PrincipalAmount { get; set; }
        public int TenureInYears { get; set; }

        public Loan()
        {
            LoanNumber = string.Empty;
            CustomerName = string.Empty;
            PrincipalAmount = 0.0m;
            TenureInYears = 0;
        }

        public Loan(string ln, string cn, decimal pa, int ty)
        {
            LoanNumber = ln;
            CustomerName = cn;
            PrincipalAmount = pa;
            TenureInYears = ty;
        }

        public decimal CalculateEmi()
        {

            decimal interest = PrincipalAmount * 0.10m * TenureInYears;
            decimal totalAmount = PrincipalAmount + interest;
            return totalAmount / (TenureInYears * 12);
        }
    }

    class HomeLoan : Loan
    {
        public HomeLoan(string ln, string cn, decimal pa, int ty)
            : base(ln, cn, pa, ty)
        {
        }

        public new decimal CalculateEmi()
        {
            decimal interest = PrincipalAmount * 0.08m * TenureInYears;
            decimal processingFee = PrincipalAmount * 0.01m;
            decimal totalAmount = PrincipalAmount + interest + processingFee;

            decimal emi = totalAmount / (TenureInYears * 12);

            return emi;
        }
    }

    class CarLoan : Loan
    {
        public CarLoan(string ln, string cn, decimal pa, int ty)
            : base(ln, cn, pa, ty)
        {
        }

        public new decimal CalculateEmi()
        {
            decimal updatedPrincipal = PrincipalAmount + 15000;

            decimal interest = updatedPrincipal * 0.09m * TenureInYears;

            decimal totalAmount = updatedPrincipal + interest;

            decimal emi = totalAmount / (TenureInYears * 12);

            return emi;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Loan[] loans = new Loan[4]
            {
                new HomeLoan("HL01", "Anita", 800000, 10),
                new HomeLoan("HL02", "Sunita", 900000, 10),
                new CarLoan("CL01", "Rahul", 600000, 6),
                new CarLoan("CL02", "Nakul", 700000, 7)
            };

            for (int i = 0; i < loans.Length; i++)
            {
                Console.WriteLine($"Emi:- {loans[i].CalculateEmi():0.00m}");
                Console.WriteLine();
            }
        }
    }
}
