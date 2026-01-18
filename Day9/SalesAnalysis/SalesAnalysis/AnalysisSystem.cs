using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAnalysis
{
    internal class AnalysisSystem
    {
        static void Main(string[] args)
        {
            decimal[] sales = new decimal[7];

            for (int i = 0; i < 7; i++)
            {
                while (true)
                {
                    Console.Write($"Enter the sales for day {i + 1}:");
                    string? input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Empty string not allowed");
                        continue;
                    }

                    bool isValid = decimal.TryParse(input, out decimal value);

                    if (!isValid || value <= 0){
                        Console.WriteLine("Invalid input! Sales must be a number and above 0");
                    }
                    else{
                        sales[i] = value;
                        break;
                    }  
                }
            }

            decimal totalSales = 0;

            for (int i = 0; i < sales.Length; i++)
            {
                totalSales += sales[i];
            }

            decimal avgSales = totalSales / 7;
            decimal maxSale = sales.Max();
            decimal minSale = sales.Min();

            int maxIndex = Array.IndexOf(sales, maxSale); 
            int minIndex = Array.IndexOf(sales, minSale);

            int daysAbovAvg = 0;
            for (int i = 0; i < sales.Length; i++)
            {
                if (sales[i] > avgSales)
                {
                    daysAbovAvg++;
                }
            }

            string[] category= new string[7];

            for (int i = 0; i < sales.Length; i++)
            {
                if (sales[i] < 5000)
                    category[i] = "LOW";
                else if (sales[i] > 15000)
                    category[i] = "HIGH";
                else
                    category[i] = "MEDIUM";
            }

            Console.WriteLine("\nWeekly Sales Report");
            Console.WriteLine("-------------------");
            Console.WriteLine($"Total Sales        : {totalSales:0.00}");
            Console.WriteLine($"Average Daily Sale : {avgSales:0.00}\n");

            Console.WriteLine($"Highest Sale       : {maxSale:0.00} (Day {maxIndex})");
            Console.WriteLine($"Lowest Sale        : {minSale:0.00} (Day {minIndex})");

            Console.WriteLine($"Days Above Average : {daysAbovAvg}");

            Console.WriteLine("Day-wise Salses Category:");
            for (int i = 0; i < category.Length; i++)
            {
                Console.WriteLine($"Day {i + 1} : {category[i]}");
            }
        }
    }
}
