using System.Xml.Linq;

namespace OrderProcessing
{

    class Order
    {
        private DateTime orderDtae;

        
        private int orderId;
        public int getOrderId
        {
            get { return orderId; }
        }


        private string customerName;
        public string CustomerName
        {
            get { return customerName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    Console.WriteLine("Invalid input for name. Not allowed");
                else
                    customerName = value;

            }
        }

        private decimal totalAmount;
        public decimal TotalAmount
        {
            get { return totalAmount; }
        }

        private string orderStatus;



        private bool discountApplied;

        public Order()
        {
            orderDtae = DateTime.Today;
            orderId = 0;
            orderStatus = "New";
            totalAmount = 0;
            customerName = "Unknown";
            discountApplied = false;

        }

        public Order(int ordId, string name)
        {
            orderDtae = DateTime.Today;
            orderId = ordId;
            customerName = name;
            orderStatus = "New";
            totalAmount = 0;
        }



        public void AddItem(decimal price)
        {
            if (price < 0)
                Console.WriteLine("Invalid price of item");
            else
                totalAmount+= price;
        }

        public void ApplyDiscount(decimal percentage)
        {
            if (discountApplied)
            {
                Console.WriteLine("Discount is already applied");
                return;
            }

            if (percentage >= 1 && percentage <= 30)
            {
                decimal discountAmount = (totalAmount * percentage) / 100;
                totalAmount -= discountAmount;
                discountApplied = true;
            }
            else
            {
                Console.WriteLine("Invalid Discount! Discount must be between 1 and 30.");
            }
        }

        public string GetOrderSummary()
        {
            return $"Order Id: {orderId}\n"+
                   $"Custometr: {customerName}\n"+
                   $"Total Amount: {totalAmount}\n"+
                   $"Status: {orderStatus}";
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order(101, "Rahul");
            order.AddItem(500);
            order.AddItem(300);
            order.ApplyDiscount(10);
            order.ApplyDiscount(10);

            Console.WriteLine(order.GetOrderSummary());

        }
    }
}
