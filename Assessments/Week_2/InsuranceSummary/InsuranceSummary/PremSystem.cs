using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceSummary
{
    internal class PremSystem
    {
        static void Main(string[] args)
        {
            string[] polHolNames = new string[5];
            double[] annPrem = new double[5];

            

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter the name and age of the Police Holder {i+1}:");
                string input = Console.ReadLine();
                string[] data = input.Split(' ');

                while (string.IsNullOrWhiteSpace(data[0])){
                    Console.Write("Name cannot be empty, Re-Enter the name:");
                    data[0] = Console.ReadLine();
                }
                while (double.Parse(data[1]) <= 0)
                {
                    Console.Write("Premium amount is below 0, Re-Enter the amount:");
                    data[1] = Console.ReadLine();
                }
                polHolNames[i] = data[0];
                annPrem[i] = double.Parse(data[1]);
            }

            double totPremAmt = 0;
            double avgPrem = 0;
            double highPrem = annPrem.Max();
            double lowPrem=annPrem.Min();

            for (int i = 0; i < 5; i++)
            {
                totPremAmt += annPrem[i];
            }
            avgPrem = totPremAmt / 5;




            Console.WriteLine("Insurance Premium Summary");
            Console.WriteLine("--------------------------");
            Console.WriteLine($"{"Name",-15}{"Premium",15}{"Category",15}");
            Console.WriteLine("-----------------------------------------------");

            for (int i = 0; i < annPrem.Length; i++)
            {
                string category;

                if (annPrem[i] < 10000)
                    category = "LOW";
                else if (annPrem[i] > 25000)
                    category = "HIGH";
                else
                    category = "MEDIUM";

                Console.WriteLine($"{polHolNames[i],-15}{annPrem[i],15:0.00}{category,15}");
            }

            Console.WriteLine();
            Console.WriteLine($"{"Total Premium",-20}: {totPremAmt:0.00}");
            Console.WriteLine($"{"Average Premium",-20}: {avgPrem:0.00}");
            Console.WriteLine($"{"Highest Premium",-20}: {highPrem:0.00}");
            Console.WriteLine($"{"Lowest Premium",-20}: {lowPrem:0.00}");


        }
        


    }
}
