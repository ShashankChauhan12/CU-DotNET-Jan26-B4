using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlLogProcessor
{
    internal class SmartAccess
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enet the Id:");
            string input = Console.ReadLine();
            string[] data = input.Split('|');

            if (data.Length != 5)
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }

            string gateCode = data[0];
            char userIni = char.Parse(data[1]);
            byte AccLev = byte.Parse(data[2]);
            bool Activ = bool.Parse(data[3]);
            byte attempt = byte.Parse(data[4]);

            string act = data[3].ToLower();


            if (gateCode.Length != 2 ||!char.IsLetter(gateCode[0]) || !char.IsDigit(gateCode[1])){
                Console.WriteLine("INVALID ACCESS LOG1");
                return;
            }

            else if(!char.IsUpper(userIni))
            {
                Console.WriteLine("INVALID ACCESS LOG 2");
                return;
            }

            else if(AccLev < 1 || AccLev > 7)
            {
                Console.WriteLine("INVALID ACCESS LOG 3");
                return;
            }
            
            else if (act != "true" && act != "false")
            {
                Console.WriteLine("INVALID ACCESS LOG 4");
                return;
            }

            else if (attempt > 200)
            {
                Console.WriteLine("INVALID ACCESS LOG 5");
                return;
            }
            Activ = bool.Parse(act);

            //Buisness Logic

            string check;

            if (Activ == false)
            {
                check="ACCESS DENIED – INACTIVE USER";
            }
            else if (attempt > 100)
            {
                check="ACCESS DENIED – TOO MANY ATTEMPTS";
            }
            else if (AccLev >= 5)
            {
                check="ACCESS GRANTED – HIGH SECURITY";
            }
            else
            {
                check = "ACCESS GRANTED – STANDARD";
            }



            Console.WriteLine($"{"Gate".PadRight(10)}: {gateCode}");
            Console.WriteLine($"{"User".PadRight(10)}: {userIni}");
            Console.WriteLine($"{"Level".PadRight(10)}: {AccLev}");
            Console.WriteLine($"{"Attempts".PadRight(10)}: {attempt}");
            Console.WriteLine($"{"Status".PadRight(10)}: {check}");
        }
    }
}
