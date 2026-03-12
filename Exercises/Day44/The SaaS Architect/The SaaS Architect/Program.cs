using System.Text;

namespace The_SaaS_Architect
{
    public abstract class Subscriber : IComparable<Subscriber>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }

        // Abstract method
        public abstract decimal CalculateMonthlyBill();

        // Equality based on ID
        public override bool Equals(object obj)
        {
            if (obj is Subscriber other)
                return ID.Equals(other.ID);

            return false;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        // Sorting by JoinDate then Name
        public int CompareTo(Subscriber other)
        {
            int dateCompare = JoinDate.CompareTo(other.JoinDate);

            if (dateCompare == 0)
                return Name.CompareTo(other.Name);

            return dateCompare;
        }
    }

    // Business Subscriber
    public class BusinessSubscriber : Subscriber
    {
        public decimal FixedRate { get; set; }
        public decimal TaxRate { get; set; }

        public override decimal CalculateMonthlyBill()
        {
            return FixedRate * (1 + TaxRate);
        }
    }

    // Consumer Subscriber
    public class ConsumerSubscriber : Subscriber
    {
        public decimal DataUsageGB { get; set; }
        public decimal PricePerGB { get; set; }

        public override decimal CalculateMonthlyBill()
        {
            return DataUsageGB * PricePerGB;
        }
    }
    public class ReportGenerator
    {
        public static void PrintRevenueReport(IEnumerable<Subscriber> subscribers)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("----------------- Revenue Report -----------------");
            sb.AppendLine(string.Format("{0,-20} {1,-12} {2,15}", "Name", "Type", "Monthly Bill"));
            sb.AppendLine(new string('-', 50));

            foreach (var sub in subscribers)
            {
                string type = sub is BusinessSubscriber ? "Business" : "Consumer";
                decimal bill = sub.CalculateMonthlyBill();

                sb.AppendLine(string.Format("{0,-20} {1,-12} {2,15:C2}", sub.Name, type, bill));
            }

            Console.WriteLine(sb.ToString());
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Subscriber> subscribers = new Dictionary<string, Subscriber>();

            subscribers.Add("corp1@company.com", new BusinessSubscriber
            {
                ID = Guid.NewGuid(),
                Name = "Tech Corp",
                JoinDate = new DateTime(2023, 5, 10),
                FixedRate = 500,
                TaxRate = 0.18m
            });

            subscribers.Add("corp2@company.com", new BusinessSubscriber
            {
                ID = Guid.NewGuid(),
                Name = "Data Systems",
                JoinDate = new DateTime(2022, 3, 15),
                FixedRate = 700,
                TaxRate = 0.18m
            });

            subscribers.Add("john@gmail.com", new ConsumerSubscriber
            {
                ID = Guid.NewGuid(),
                Name = "John",
                JoinDate = new DateTime(2024, 1, 20),
                DataUsageGB = 50,
                PricePerGB = 2
            });

            subscribers.Add("sara@gmail.com", new ConsumerSubscriber
            {
                ID = Guid.NewGuid(),
                Name = "Sara",
                JoinDate = new DateTime(2024, 2, 10),
                DataUsageGB = 30,
                PricePerGB = 2
            });

            subscribers.Add("alex@gmail.com", new ConsumerSubscriber
            {
                ID = Guid.NewGuid(),
                Name = "Alex",
                JoinDate = new DateTime(2023, 11, 5),
                DataUsageGB = 100,
                PricePerGB = 1.5m
            });

            // 2. Sort dictionary by Monthly Bill (Descending)
            var sortedSubscribers = subscribers
                .OrderByDescending(x => x.Value.CalculateMonthlyBill())
                .Select(x => x.Value)
                .ToList();

            // 4. Print Report
            ReportGenerator.PrintRevenueReport(sortedSubscribers);
        }
    }
}
