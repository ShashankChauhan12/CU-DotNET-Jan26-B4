namespace MessageProcessor
{
    internal class LoginStatus
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enetr the Login status message");
            string input=Console.ReadLine();
            string[] data = input.Split('|');

            string name=data[0];
            string message=data[1];

            string cleanMessage = message.Trim().ToLower();

            bool isFound = cleanMessage.Contains("successful");


            string standard = "login successful";
            bool compStr = cleanMessage.Equals(standard);


            string status;
            if (!isFound)
            {
                status = "LOGIN FAILED";
            }
            else if(isFound && compStr)
            {
                status = "LOGIN SUCCESS";
            }
            else
            {
                status = "LOGIN SUCCESS(CUSTOM MESSAGE)";
            }

            Console.WriteLine($"{"User".PadRight(8)}:{name}");
            Console.WriteLine($"{"Message".PadRight(8)}:{cleanMessage}");
            Console.WriteLine($"{"Satus".PadRight(8)}:{status}");
    }
}
}
