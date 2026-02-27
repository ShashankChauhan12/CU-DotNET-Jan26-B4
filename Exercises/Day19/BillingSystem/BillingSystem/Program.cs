using BillingSystem;

namespace BillingSystem
{

    abstract class UtilityBill
    {
        public int ConsumerId { get; set; }
        public string ConsumerName { get; set; }

        public decimal UnitsConsumed { get; set; }
        public decimal RatePerUnit { get; set; }


        protected UtilityBill(int cI,string cN,decimal uC,decimal rPU)
        {
            ConsumerId = cI;
            ConsumerName = cN;
            UnitsConsumed = uC;
            RatePerUnit = rPU;
        }
        public abstract decimal CalculateBillAmount();

        public virtual decimal CalculateTax(decimal billAmount)
        {
            return billAmount * 0.05m;
        }

        public void PrintBill()
        {
            decimal billAmount= CalculateBillAmount();
            decimal tax = CalculateTax(billAmount);
            
            Console.WriteLine($"ConsumerId:- {ConsumerId}\n ConsumerName:- {ConsumerName}\n UnitsConsumed:- {UnitsConsumed
                }\n RatePerUnit:- {RatePerUnit}\n BillAmount:- {CalculateBillAmount()}\n Taxamount:- {CalculateTax(billAmount)}\nTotalPayble:- {billAmount+tax}\n");
        }
    }

    class ElectricityBill : UtilityBill
    {
        public ElectricityBill(int cI, string cN, decimal uC, decimal rPU) : base(cI, cN, uC, rPU)
        {
        }

        public override decimal CalculateBillAmount()
        {
            decimal amount = UnitsConsumed * RatePerUnit;
            if (UnitsConsumed > 300)
            {
                amount += amount * 0.10m;
            }
            return amount;
        }
    }

    class WaterBill : UtilityBill
    {
        public WaterBill(int cI, string cN, decimal uC, decimal rPU) : base(cI, cN, uC, rPU)
        {
        }
        public override decimal CalculateBillAmount()
        {
            return UnitsConsumed * RatePerUnit;
        }

        public override decimal CalculateTax(decimal billAmount)
        {
            return billAmount*0.02m;
        }
    }


    class GasBill : UtilityBill
    {
        public GasBill(int cI, string cN, decimal uC, decimal rPU) : base(cI, cN, uC, rPU)
        {
        }
        public override decimal CalculateBillAmount()
        {
            return (UnitsConsumed * RatePerUnit)+150;
        }

        public override decimal CalculateTax(decimal billAmount)
        {
            return 0m;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<UtilityBill> bills = new List<UtilityBill>
            {
                new ElectricityBill(101, "Nishant", 350, 6.5m),
                new WaterBill(102, "Vansh", 120, 2.0m),
                new GasBill(103, "Mayank", 40, 8.0m)
            };

            foreach (var item in bills)
            {
                item.PrintBill();
            }
        }
    }
}


