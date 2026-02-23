namespace OlaDriver
{
    class Ride
    {
        public int RideId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public double Fare { get; set; }

        public Ride(int rId, string fr, string to, double far)
        {
            RideId = rId;
            From = fr;
            To = to;
            Fare = far;
        }
    }


    internal class OlaDriver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VehicleNo { get; set; }
        public List<Ride> Rides { get; set; }

        public OlaDriver(int id, string name, string vehicleNo)
        {
            Id = id;
            Name = name;
            VehicleNo = vehicleNo;
            Rides = new List<Ride>();
        }

        public double GetTotalFare()
        {
            double total = 0;

            foreach (Ride r in Rides)
            {
                total += r.Fare;
            }

            return total;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<OlaDriver> drivers = new List<OlaDriver>();



            OlaDriver d1 = new OlaDriver(22, "Suresh", "UP 85 SS 1234");

            d1.Rides.Add(new Ride(121, "Delhi", "Faridabad", 700));
            d1.Rides.Add(new Ride(150, "Faridabad", "Palwal", 200));

            drivers.Add(d1);

            OlaDriver d2 = new OlaDriver(44, "Nishant", "AP 44 SE 1234");
            d2.Rides.Add(new Ride(101, "Pune", "Mumbai", 1000));
            d2.Rides.Add(new Ride(108, "Mumbai", "Nasik", 1500));

            drivers.Add(d2);


            foreach (var driver in drivers)
            {
                Console.WriteLine("\n--------------------------------");
                Console.WriteLine($"Driver ID: {driver.Id}");
                Console.WriteLine($"Name: {driver.Name}");
                Console.WriteLine($"Vehicle No: {driver.VehicleNo}");
                Console.WriteLine("Rides:");

                foreach (var ride in driver.Rides)
                {
                    Console.WriteLine(
                        $"RideId: {ride.RideId}, From: {ride.From}, To: {ride.To}, Fare: {ride.Fare}");
                }

                Console.WriteLine($"Total Fare: {driver.GetTotalFare()}");
            }

        }
    }
}
