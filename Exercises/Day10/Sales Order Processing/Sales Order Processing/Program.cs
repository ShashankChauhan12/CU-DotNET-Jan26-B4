namespace Sales_Order_Processing
{
    internal class Program
    {
        static void ReadWeeklySales(decimal[] sales)
        {
            Console.WriteLine("Enter sales for each day of the week:"); ;
            for (int i = 0; i < 7; i++)
            {
                sales[i] = decimal.Parse(Console.ReadLine());
                if (sales[i] < 0)
                {
                    Console.WriteLine("Sale was in negative value. Re-enter valid sale:");
                    sales[i] = decimal.Parse(Console.ReadLine());
                }
            }
        }
        static decimal CalculateAverage(decimal total, int days)
        {
            return total / days;
        }
        static decimal CalculateTotal(decimal[] sales)
        {
            decimal totalSales = 0;
            for (int i = 0; i < sales.Length; i++)
            {
                totalSales += sales[i];
            }
            return totalSales;
        }
        static decimal FindHighestSale(decimal[] sales, out int day1)
        {
            day1 = -1;
            decimal max = decimal.MinValue;
            for (int i = 0; i < sales.Length; i++)
            {
                if (sales[i] > max)
                {
                    day1 = i;
                    max = sales[i];
                }

            }
            return max;

        }
        static decimal FindLowestSale(decimal[] sales, out int day2)
        {
            day2 = -1;
            decimal min = decimal.MaxValue;
            for (int i = 0; i < sales.Length; i++)
            {
                if (sales[i] < min)
                {
                    day2 = i;
                    min = sales[i];
                }

            }
            return min;

        }
        static decimal CalculateDiscount(decimal total)
        {
            decimal discount = 0;
            if (total >= 50000)
            {
                discount = 10;
            }
            else
            {
                discount = 5;
            }
            return discount;
        }
        static decimal CalculateDiscount(decimal total, bool isFestivalWeek)
        {
            decimal discount = 0;
            decimal amount = 0;
            if (isFestivalWeek && total >= 50000)
            {
                discount = 15;
            }
            else if (isFestivalWeek && total < 50000)
            {
                discount = 10;
            }
            else
            {
                discount = 5;
            }
            amount = (decimal)(discount / 100) * total;
            return amount;
        }
        static decimal CalculateTax(decimal amount)
        {
            decimal tax = (decimal)0.18 * amount;
            return tax;
        }
        static decimal CalculateFinalAmount(decimal total, decimal discount, decimal tax)
        {
            return (decimal)total + tax - discount;

        }
        static void GenerateSalesCategory(decimal[] sales, string[] categories)
        {
            for (int i = 0; i < sales.Length; i++)
            {
                if (sales[i] < 5000)
                {
                    categories[i] = "Low";
                }
                else if (sales[i] > 5000 && sales[i] < 15000)
                {
                    categories[i] = "Medium";

                }
                else
                {
                    categories[i] = "High";
                }
            }
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine($"Day {i + 1} : {categories[i]}");
            }

        }

        static void Main(string[] args)
        {
            int size = 7;
            decimal discount = 0;
            int day1 = 0;
            int day2 = 0;
            String[] categories = new string[size];
            decimal[] sales = new decimal[size];
            decimal discountedAmount = 0;
            decimal tax = 0;
            decimal finalPayable = 0;
            ReadWeeklySales(sales);


            Console.WriteLine("Weekly Sales Summary");
            Console.WriteLine("--------------------");

          
            decimal totalSales = CalculateTotal(sales);
            Console.WriteLine($"Total sales :{totalSales:F2}");

            decimal avgSales = CalculateAverage(totalSales, size);
            Console.WriteLine($"Average Daily Sale :{avgSales:F2}");
            Console.WriteLine();
            Console.WriteLine();


            FindHighestSale(sales, out day1);
            Console.WriteLine($"Highest Sale :{sales[day1]:F2} (Day {day1})");

            FindLowestSale(sales, out day2);
            Console.WriteLine($"Lowest Sale :{sales[day2]:F2} (Day {day2})");
            Console.WriteLine();
            Console.WriteLine();


            string FestiveWeek;

            Console.WriteLine("Is this festival week? Enter true or false:");
            FestiveWeek = Console.ReadLine().ToLower();

            while (!(FestiveWeek == "true" || FestiveWeek == "false"))
            {
                Console.WriteLine("Invalid input please enter again:");
                FestiveWeek = Console.ReadLine().ToLower();
            }

            bool isFestiveWeek = bool.Parse(FestiveWeek);
            if (isFestiveWeek)
            {
                discount = CalculateDiscount(totalSales, isFestiveWeek);
                Console.WriteLine($"Discount Appiled :{discount:F2}");
                discountedAmount = totalSales - discount;
                tax = CalculateTax(discountedAmount);
                Console.WriteLine($"Tax Amount : {tax:F2}");
                finalPayable = CalculateFinalAmount(totalSales, discount, tax);
                Console.WriteLine($"Final Payable :{finalPayable:F2}");


            }
            else
            {
                discount = CalculateDiscount(totalSales);
                Console.WriteLine($"Discount Appiled :{discount:F2}");
                discountedAmount = totalSales - discount;
                tax = CalculateTax(discountedAmount);
                Console.WriteLine($"Tax Amount : {tax:F2}");
                finalPayable = CalculateFinalAmount(totalSales, discount, tax);
                Console.WriteLine($"Final Payable :{finalPayable:F2}");

            }

            Console.WriteLine("Day-wise Category:");
            GenerateSalesCategory(sales, categories);

        }
    }
}
