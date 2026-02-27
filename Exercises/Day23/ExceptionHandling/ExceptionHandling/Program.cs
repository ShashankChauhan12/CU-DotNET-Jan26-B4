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
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter first number: ");
                int a = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter second number: ");
                int b = int.Parse(Console.ReadLine());

                int result = a / b;
                Console.WriteLine("Result: " + result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Number can't be divide by 0");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number format.");
            }
            finally
            {
                Console.WriteLine("Operation Completed");
            }

            try
            {
                Console.WriteLine("Enter a number: ");
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine($"You entered: {num}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number format.");
            }
            finally
            {
                Console.WriteLine("Operation Completed");
            }

            try
            {
                int[] arr = { 10, 20, 30 };
                Console.Write("Enter array index (0-2): ");
                int index = int.Parse(Console.ReadLine());
                Console.WriteLine($"Value: {arr[index]}");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Error: Index out of range.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number format.");
            }
            finally
            {
                Console.WriteLine("Operation Completed");
            }

            try
            {
                string studentName = GetStudentName();
                int studentAge = GetStudentAge();

                Console.WriteLine("\nStudent Enrolled Successfully!");
                Console.WriteLine($"Name: {studentName}, Age: {studentAge}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nMessage: " + ex.Message);

                if (ex.InnerException != null)
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);

                Console.WriteLine("\nStackTrace:");
                Console.WriteLine(ex.StackTrace);
            }
        }

        static int GetStudentAge()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter Student Age: ");
                    int age = int.Parse(Console.ReadLine());

                    if (age < 18 || age > 60)
                        throw new InvalidStudentAgeException("Age must be between 18 and 60.");

                    return age;
                }
                catch (InvalidStudentAgeException ex)
                {
                    throw new Exception("Student Age Validation Failed", ex);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
        }

        static string GetStudentName()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter Student Name: ");
                    string name = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(name))
                        throw new InvalidStudentNameException("Student name cannot be empty.");

                    return name;
                }
                catch (InvalidStudentNameException ex)
                {
                    throw new Exception("Student Name Validation Failed", ex);
                }
            }
        }
    }
}






