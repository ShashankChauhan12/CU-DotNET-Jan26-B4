namespace ExceptionHandling
{
    class InvalidStudentNameException : Exception
    {
        public InvalidStudentNameException(string message) : base(message)
        {

        }
    }
    class InvalidStudentAgeException : Exception
    {
        public InvalidStudentAgeException(string message) : base(message) { }
    }

    internal class Program
    {
        static void checkName()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter the name: ");
                    string name = Console.ReadLine();
                    for (int i = 0; i < name.Length; i++)
                    {
                        if (!char.IsLetter(name[i]))
                        {
                            throw new InvalidStudentNameException("The name should contain all the letters.");
                        }
                    }
                    Console.WriteLine("You have entered the correct name. Thank you");
                    break;
                }
                catch (InvalidStudentNameException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        static void CheckAge()
        {

            while (true)
            {
                try
                {
                    Console.Write("Enter the age: ");
                    int age = int.Parse(Console.ReadLine());
                    if (age < 18 || age > 60)
                    {
                        throw new InvalidStudentAgeException("Age should be between 18 and 60");
                    }
                    Console.WriteLine("You have entered the correct age.");
                    break;
                }

                catch (InvalidStudentAgeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        static void Div()
        {
            try
            {
                Console.Write("Enter the first number: ");
                int num1 = int.Parse(Console.ReadLine());
                Console.Write("Enter the second number: ");
                int num2 = int.Parse(Console.ReadLine());
                int div = num1 / num2;
            }
            catch (FormatException f)
            {
                Console.WriteLine(f.Message);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void CheckArr()
        {
            try
            {
                int[] arr = new int[5];
                Console.Write("Enter the elements of array: ");
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = int.Parse(Console.ReadLine());
                }
               // Console.WriteLine(arr[10]);
            }
            catch (IndexOutOfRangeException i)
            {
                Console.WriteLine(i.Message);
                throw new Exception();
            }
        }
        static void Main(string[] args)
        {
            try
            {
                checkName();
                CheckAge();
                Div();
                CheckArr();
            }

            catch (Exception e)
            {
                Console.WriteLine("Message : " + e.Message);
                Console.WriteLine("InnerException : " + e.InnerException);
                Console.WriteLine("StackTrace : " + e.StackTrace);
            }
            finally
            {
                Console.WriteLine("Operation Completed");
            }
        }
    }
}
