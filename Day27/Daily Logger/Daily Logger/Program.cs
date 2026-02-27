namespace Daily_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"..\..\..\journal.txt";

            Console.WriteLine("Enter your Daily Reflection:");
            string reflection = Console.ReadLine();

            string entry = $"{reflection}";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(entry);
            }

            Console.WriteLine("Your reflection saved.");
        }
    }
}
