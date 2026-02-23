using System.Reflection.PortableExecutable;

namespace LoanPortfolio
{
    class Loan
    {
        public string ClientName { get; set; }
        public double Principal { get; set; }
        public double InterestRate { get; set; }
    }
    internal class Program
    {
        static string LoanData = @"..\..\..\loansData";

        static void Main(string[] args)
        {
            WriteLoanToFile();
            ReadLoansFromFile();
        }

        static void WriteLoanToFile() {

            bool IsExist = File.Exists(LoanData);


            using (StreamWriter rw = new StreamWriter(LoanData, true))
            {
                if (!IsExist)
                {
                    rw.WriteLine("Client,Principal,InterestRate");
                }
                Console.Write("Enter the Client Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter the Principal: ");
                double principal = double.Parse(Console.ReadLine());

                Console.Write("Enter the Interest Rate (%): ");
                double rate = double.Parse(Console.ReadLine());

                rw.WriteLine($"{name},{principal},{rate}");
            }
        }
        static void ReadLoansFromFile() {
            Console.WriteLine();
            Console.WriteLine("CLIENT     | PRINCIPAL       | INTEREST        | RISK LEVEL");
            Console.WriteLine("-----------------------------------------------------------");

            using (StreamReader rr = new StreamReader(LoanData))
            {
                rr.ReadLine();
                while (!rr.EndOfStream)
                {
                    string line = rr.ReadLine();
                    string[] parts = line.Split(',');

                    if (parts.Length != 3)
                        continue;

                    string name = parts[0];

                    if (!double.TryParse(parts[1], out double principal) ||
                        !double.TryParse(parts[2], out double rate))
                    {
                        Console.WriteLine($"Invalid data for {name}. Skipped.");
                        continue;
                    }

                    double totalInterest = principal * rate / 100;

                    string risk = string.Empty;

                    if (rate > 10)
                    {
                        risk = "High Risk";
                    }
                    else if (rate < 5)
                    {
                        risk = "Low Risk";
                    }
                    else
                    {
                        risk = "Medium Risk";
                    }
                    Console.OutputEncoding = System.Text.Encoding.UTF8;


                    Console.WriteLine(
                        $"{name.PadRight(10)} | " +
                        $"{principal.ToString("C").PadRight(14)} | " +
                        $"{totalInterest.ToString("C").PadRight(14)} | " +
                        $"{risk}");
                }
            }
        }

        
    }
}

