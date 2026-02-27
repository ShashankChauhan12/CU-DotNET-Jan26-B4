namespace StudentPerformanceAnalytics
{

    class Student
    {
    public int Id;
    public string Name;
    public string Class;
    public int Marks;
}



internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>{
                new Student{Id=1, Name="Amit", Class="10A", Marks=85},
                new Student{Id=2, Name="Neha", Class="10A", Marks=72},
                new Student{Id=3, Name="Rahul", Class="10B", Marks=90},
                new Student{Id=4, Name="Pooja", Class="10B", Marks=60},
                new Student{Id=5, Name="Kiran", Class="10A", Marks=95}
            };

            var top3 = students.OrderByDescending(s => s.Marks).Take(3);

            Console.WriteLine("Top three students are: ");
            foreach (var s in top3)
            {
                Console.WriteLine(s.Name + " - " + s.Marks);
            }

            var avgByClass = students
                .GroupBy(s => s.Class)
                .Select(g => new
                {
                    Class = g.Key,
                    Avg = g.Average(x => x.Marks)
                }
             );

            var belowAvg = students
                .GroupBy(s => s.Class)
                . SelectMany(g =>
                {
                    var avg = g.Average(x => x.Marks);
                    return g.Where(x => x.Marks < avg);
                });

            var ordered = students
                .OrderBy(s => s.Class)
                .ThenByDescending(s => s.Marks);
        }
    }
}
