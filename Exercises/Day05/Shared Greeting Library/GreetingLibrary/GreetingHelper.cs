namespace GreetingLibrary
{
    public class GreetingHelper
    {
        public static string GetGreeting(string name)
        {
            if (name == null || name == "")
            {
                return "Hello, Guest!";
            }
            else
            {
                return "Hello, " + name + "!";
            }
        }
    }
}
