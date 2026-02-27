namespace DisplayLine
{
    internal class Program
    {
        public static void Display(int num = 40, char ch = '-')
        {
            for (int i = 0; i < num; i++)
            {
                Console.Write(ch);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Display();
            Display(ch: '+');
            Display(60, '$');
        }
    }
}
