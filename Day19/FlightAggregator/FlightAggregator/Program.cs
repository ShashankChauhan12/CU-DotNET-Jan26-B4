using System.Collections.Generic;
using System.Diagnostics;

namespace FlightAggregator
{
    class Flight: IComparable<Flight>
    {
        public string FlightNumber { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime DepartureTime { get; set; }

        public int CompareTo(Flight? other)
        {
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return $"FLight No:-{FlightNumber} | Price:- {Price} | Duration:-{Duration} | DepartureTime:- {DepartureTime}";
        }
    }

    class DurationComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
            return x.Duration.CompareTo(y?.Duration);
        }
    }
    class DepartureComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
            return x.DepartureTime.CompareTo(y?.DepartureTime);

        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Flight> flights = new List<Flight>()
            {
                new Flight()
                {
                    FlightNumber= "1",
                    Price=15000.78m,
                    Duration = TimeSpan.FromHours(3),
                    DepartureTime = DateTime.Today.AddHours(9)
                },
                new Flight()
                {
                    FlightNumber= "2",
                    Price=17000.28m,
                    Duration = TimeSpan.FromHours(1),
                    DepartureTime = DateTime.Today.AddHours(7)
                },
                new Flight()
                {
                    FlightNumber= "3",
                    Price=145000.58m,
                    Duration = TimeSpan.FromHours(3),
                    DepartureTime = DateTime.Today.AddHours(5)
                }
            };

            flights.Sort();
            foreach (var item in flights)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            flights.Sort(new DurationComparer());
            foreach (var item in flights)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            flights.Sort(new DepartureComparer());
            foreach (var item in flights)
            {
                Console.WriteLine(item);
            }





        }
    }
}

