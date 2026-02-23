namespace ScoreLeaderboard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<double,string> leaderboard=new SortedDictionary<double,string>();

            leaderboard.Add(55.42, "SwiftRacer");
            leaderboard.Add(52.10, "SpeedDemon");
            leaderboard.Add(58.91, "SteadyEddie");
            leaderboard.Add(51.05, "TurboTom");


            foreach (var entry in leaderboard)
            {
                Console.WriteLine($"{entry.Value} - {entry.Key} seconds");
            }
            Console.WriteLine();


            double keyToRemove = leaderboard
                .Where(x => x.Value == "SteadyEddie")
                .Select(x => x.Key)
                .First();

            leaderboard.Remove(keyToRemove);

            leaderboard.Add(54.00, "SteadyEddie");

            foreach (var entry in leaderboard)
            {
                Console.WriteLine($"{entry.Value} - {entry.Key} seconds");
            }
        }
    }
}
