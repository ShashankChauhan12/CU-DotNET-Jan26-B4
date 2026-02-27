namespace Tracker
{
    class ApplicationConfig
    {
        public static string ApplicationName { get; set; }
        public static string Environment { get; set; }
        public static int AccessCount { get; set; }
        public static bool IsInitialized { get; set; }

        static ApplicationConfig()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            AccessCount = 0;
            IsInitialized = false;
            Console.WriteLine("Static Constructor called");
        }

        public static void Initialize(string appName, string environment)
        {
            ApplicationName = appName;
            Environment = environment;
            IsInitialized = true;
            AccessCount++;
        }

        public static string GetConfigurationSummary()
        {
            AccessCount++;
            return $"Application Name: {ApplicationName}\n" +
                $"Environment: {Environment}\n" +
                $"Access Count: {AccessCount}\n" +
                $"Initialization Staus: {IsInitialized}";
        }


        public static void ResetConfiguration()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            IsInitialized = false;
            AccessCount++;

        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Triggered static constructor: " + ApplicationConfig.ApplicationName);

            Console.WriteLine();

            ApplicationConfig.Initialize("FitApp", "Production");

            string check = ApplicationConfig.GetConfigurationSummary();
            Console.WriteLine("Configuration Summary");
            Console.WriteLine(check);

            Console.WriteLine();

            ApplicationConfig.ResetConfiguration();

            string reset = ApplicationConfig.GetConfigurationSummary();
            Console.WriteLine("After Reset Summary");
            Console.WriteLine(reset);

        }
    }
}

