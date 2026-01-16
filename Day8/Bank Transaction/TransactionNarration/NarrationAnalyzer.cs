using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionNarration
{
    internal class NarrationAnalyzer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the details: ");
            string input = Console.ReadLine();
            string[] data = input.Split('#');

            string transactId = data[0];
            string accHolName = data[1];
            string transacNarrat = data[2];

            transacNarrat = transacNarrat.Trim();

            while (transacNarrat.Contains("  "))
            {
                transacNarrat = transacNarrat.Replace("  ", " ");
            }

            transacNarrat = transacNarrat.ToLower();

            bool keyword = transacNarrat.Contains("deposit") || transacNarrat.Contains("withdrawal") || transacNarrat.Contains("transfer");

            bool standard = transacNarrat.Equals("cash deposit successful");

            string category;

            if (!keyword){
                category="NON - FINANCIAL TRANSACTION";
            }
            else if(keyword && standard){
                category= "STANDARD TRANSACTION";
            }
            else{
                category = "CUSTOM TRANSACTION";
            }


            Console.WriteLine($"Transaction ID : {transactId}");
            Console.WriteLine($"Account Holder : {accHolName}");
            Console.WriteLine($"Narration     : {transacNarrat}");
            Console.WriteLine($"Category      : {category}");

        }
    } 
}
