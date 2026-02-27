using GreetingLibrary;

namespace Shared_Greeting_Library
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter your name:");
            string name = Console.ReadLine();

            string message = GreetingHelper.GetGreeting(name);
            Console.WriteLine(message);
        }
    }
}
