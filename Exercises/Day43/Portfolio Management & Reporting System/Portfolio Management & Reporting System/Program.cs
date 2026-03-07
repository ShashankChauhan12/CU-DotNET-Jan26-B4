namespace Portfolio_Management___Reporting_System
{
    class InvalidFinancialDataException : Exception
    {
        public InvalidFinancialDataException(string message) : base(message) { }
    }

    interface IRiskAssessable
    {
        string GetRiskCategory();
    }

    interface IReportable
    {
        string GenerateReportLine();
    }

    abstract class FinancialInstrument
    {
        private decimal quantity;
        private decimal purchasePrice;

        public string InstrumentId { get; set; }
        public string Name { get; set; }

        private string currency;
        public string Currency
        {
            get => currency;
            set
            {
                if (value.Length != 3)
                    throw new InvalidFinancialDataException("Currency must be 3 letters");
                currency = value;
            }
        }

        public DateTime PurchaseDate { get; set; }

        public decimal Quantity
        {
            get => quantity;
            set
            {
                if (value < 0)
                    throw new InvalidFinancialDataException("Quantity cannot be negative");
                quantity = value;
            }
        }

        public decimal PurchasePrice
        {
            get => purchasePrice;
            set
            {
                if (value < 0)
                    throw new InvalidFinancialDataException("Price cannot be negative");
                purchasePrice = value;
            }
        }

        public decimal MarketPrice { get; set; }

        public abstract decimal CalculateCurrentValue();

        public virtual string GetInstrumentSummary()
        {
            return $"{InstrumentId} - {Name} ({Currency})";
        }
    }

    class Equity : FinancialInstrument, IRiskAssessable, IReportable
    {
        public override decimal CalculateCurrentValue()
        {
            return Quantity * MarketPrice;
        }

        public string GetRiskCategory() => "High";

        public string GenerateReportLine()
        {
            return $"{InstrumentId} | Equity | {CalculateCurrentValue():C}";
        }
    }

    class Bond : FinancialInstrument, IRiskAssessable, IReportable
    {
        public override decimal CalculateCurrentValue()
        {
            return Quantity * MarketPrice;
        }

        public string GetRiskCategory() => "Low";

        public string GenerateReportLine()
        {
            return $"{InstrumentId} | Bond | {CalculateCurrentValue():C}";
        }
    }

    class FixedDeposit : FinancialInstrument
    {
        public override decimal CalculateCurrentValue()
        {
            return Quantity * MarketPrice;
        }
    }

    class MutualFund : FinancialInstrument
    {
        public override decimal CalculateCurrentValue()
        {
            return Quantity * MarketPrice;
        }
    }

    class Portfolio
    {
        private List<FinancialInstrument> instruments = new List<FinancialInstrument>();
        private Dictionary<string, FinancialInstrument> lookup = new Dictionary<string, FinancialInstrument>();

        public void AddInstrument(FinancialInstrument instrument)
        {
            if (lookup.ContainsKey(instrument.InstrumentId))
                throw new Exception("Duplicate Instrument ID");

            instruments.Add(instrument);
            lookup[instrument.InstrumentId] = instrument;
        }

        public decimal GetTotalPortfolioValue()
        {
            return instruments.Sum(i => i.CalculateCurrentValue());
        }

        public FinancialInstrument GetInstrumentById(string id)
        {
            return lookup.ContainsKey(id) ? lookup[id] : null;
        }

        public IEnumerable<FinancialInstrument> GetInstrumentsByRisk(string risk)
        {
            return instruments
                .OfType<IRiskAssessable>()
                .Where(i => i.GetRiskCategory() == risk)
                .Cast<FinancialInstrument>();
        }

        public List<FinancialInstrument> GetAll()
        {
            return instruments;
        }
    }

    class Transaction
    {
        public string TransactionId { get; set; }
        public string InstrumentId { get; set; }
        public string Type { get; set; }
        public decimal Units { get; set; }
        public DateTime Date { get; set; }
    }

    class ReportGenerator
    {
        public static void GenerateConsoleReport(Portfolio portfolio)
        {
            Console.WriteLine("===== PORTFOLIO SUMMARY =====");

            var grouped = portfolio.GetAll().GroupBy(i => i.GetType().Name);

            foreach (var group in grouped)
            {
                decimal investment = group.Sum(i => i.PurchasePrice * i.Quantity);
                decimal current = group.Sum(i => i.CalculateCurrentValue());

                Console.WriteLine($"\nInstrument Type: {group.Key}");
                Console.WriteLine($"Total Investment: {investment:C}");
                Console.WriteLine($"Current Value: {current:C}");
                Console.WriteLine($"Profit/Loss: {(current - investment):C}");
            }

            Console.WriteLine($"\nOverall Portfolio Value: {portfolio.GetTotalPortfolioValue():C}");

            var riskGroups = portfolio.GetAll()
                .OfType<IRiskAssessable>()
                .GroupBy(r => r.GetRiskCategory());

            Console.WriteLine("\nRisk Distribution:");
            foreach (var r in riskGroups)
            {
                Console.WriteLine($"{r.Key}: {r.Count()}");
            }
        }

        public static void GenerateFileReport(Portfolio portfolio)
        {
            string fileName = $"PortfolioReport_{DateTime.Now:yyyyMMdd}.txt";

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine("PORTFOLIO REPORT");
                sw.WriteLine("Generated: " + DateTime.Now);

                foreach (var i in portfolio.GetAll())
                {
                    sw.WriteLine($"{i.GetInstrumentSummary()} | Value: {i.CalculateCurrentValue():C}");
                }

                sw.WriteLine("\nTotal Value: " + portfolio.GetTotalPortfolioValue().ToString("C"));
            }
        }
    }
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Portfolio portfolio = new Portfolio();

            try
            {
                string csv = "EQ101,Equity,TCS,INR,80,3200,3500";
                var parts = csv.Split(',');

                FinancialInstrument eq = new Equity
                {
                    InstrumentId = parts[0],
                    Name = parts[2],
                    Currency = parts[3],
                    Quantity = decimal.Parse(parts[4]),
                    PurchasePrice = decimal.Parse(parts[5]),
                    MarketPrice = decimal.Parse(parts[6]),
                    PurchaseDate = DateTime.Now
                };

                portfolio.AddInstrument(eq);


                FinancialInstrument bond = new Bond
                {
                    InstrumentId = "BD210",
                    Name = "Corporate Bond",
                    Currency = "INR",
                    Quantity = 30,
                    PurchasePrice = 2000,
                    MarketPrice = 2150,
                    PurchaseDate = DateTime.Now
                };

                portfolio.AddInstrument(bond);


                FinancialInstrument fd = new FixedDeposit
                {
                    InstrumentId = "FD501",
                    Name = "SBI FD",
                    Currency = "INR",
                    Quantity = 10,
                    PurchasePrice = 5000,
                    MarketPrice = 5200,
                    PurchaseDate = DateTime.Now
                };

                portfolio.AddInstrument(fd);

                Transaction[] transactions =
                {
                    new Transaction{TransactionId="TX01",InstrumentId="EQ101",Type="Buy",Units=80,Date=DateTime.Now},
                    new Transaction{TransactionId="TX02",InstrumentId="BD210",Type="Buy",Units=30,Date=DateTime.Now},
                    new Transaction{TransactionId="TX03",InstrumentId="FD501",Type="Buy",Units=10,Date=DateTime.Now}
                };

                List<Transaction> transactionList = transactions.ToList();

                ReportGenerator.GenerateConsoleReport(portfolio);
                ReportGenerator.GenerateFileReport(portfolio);
            }
            catch (InvalidFinancialDataException ex)
            {
                Console.WriteLine("Data Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
