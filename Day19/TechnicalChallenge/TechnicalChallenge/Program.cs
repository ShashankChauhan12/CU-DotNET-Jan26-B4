using System.Threading.Channels;

namespace TechnicalChallenge
{

    abstract class Vehicle
    {
        public string ModelName { get; set; }

        public Vehicle( string name)
        {
            ModelName = name;
        }

        public abstract void Move();

        public virtual string GetFuelStatus()
        {
            return $"Fuel level is stable";
        }
    }

    class ElectricCar : Vehicle
    {
        public ElectricCar(string name):base( name)
        {  
        }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is gliding silently on battery power.");
        }

        public override string GetFuelStatus()
        {
            return $"{ModelName} battery is at 80%.";
        }
    }

    class Heavytruck : Vehicle
    {
        public Heavytruck(string name) : base(name)
        {
        }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is hauling cargo with high-torque diesel power.");
        }
    }


    class CargoPlane : Vehicle
    {

        public CargoPlane(string name) : base(name)
        {
        }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is ascending to 30,000 feet.");
        }
        public override string GetFuelStatus()
        {
            return base.GetFuelStatus()+ $"Checking jet fuel reserves...";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle[] vehic=new Vehicle[]
            {
                new ElectricCar("Punch"),
                new Heavytruck("Ashok LeyLand"),
                new CargoPlane("X-1100")
            };

            for (int i = 0; i < vehic.Length; i++)
            {
                vehic[i].Move();
                Console.WriteLine(vehic[i].GetFuelStatus());
                Console.WriteLine();
                    
            }
        }
    }
}
