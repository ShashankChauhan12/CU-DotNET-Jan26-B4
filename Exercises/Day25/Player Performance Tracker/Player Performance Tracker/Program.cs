namespace Player_Performance_Tracker
{
    public class Player
    {
        public string Name { get; set; }
        public int RunsScored { get; set; }
        public int BallsFaced { get; set; }
        public bool IsOut { get; set; }
        public double StrikeRate { get; set; }
        public double Average { get; set; }

        public double CalculateStrikeRate()
        {
            return (double)RunsScored / BallsFaced * 100;
        }

        public double CalculateAverage()
        {
            if (!IsOut)
                return (double)RunsScored;
            return (double)RunsScored;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string file = @"..\..\..\players.csv";
                using (FileStream fs = new FileStream(file, FileMode.Create))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    string[] s =
                    {
                        "Samson,88,45,True",
                        "Gayle,100,60,False",
                        "Kohli,56,47,True"
                    };
                    foreach (string line in s)
                    {
                        sw.WriteLine(line);
                    }
                }

                string[] lines = File.ReadAllLines(file);
                List<Player> p = new List<Player>();
                foreach (var line in lines)
                {
                    string[] info = line.Split(',');
                    Player pl = new Player()
                    {
                        Name = info[0],
                        RunsScored = int.Parse(info[1]),
                        BallsFaced = int.Parse(info[2]),
                        IsOut = bool.Parse(info[3])
                    };
                    pl.StrikeRate = pl.CalculateStrikeRate();
                    pl.Average = pl.CalculateAverage();
                    p.Add(pl);
                }
                var v = p.Where(p => p.BallsFaced >= 10).OrderByDescending(p => p.StrikeRate).ToList();
                Console.WriteLine("Name      Runs    SR      Avg");
                Console.WriteLine("---------------------------------------");
                foreach (var pl in p)
                {
                    Console.WriteLine($"{pl.Name,-7} {pl.RunsScored,5} {pl.StrikeRate,8:F2} {pl.Average,8:F2}");
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
