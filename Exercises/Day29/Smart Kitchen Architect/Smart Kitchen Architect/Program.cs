namespace Smart_Kitchen_Architect
{
    interface ITimer
    {
        void SetTimer(int minutes);
    }

    interface ISmart
    {
        void ConnectWifi();
    }

    abstract class KitchenAppliance
    {
        public string ModelName { get; set; }
        public int PowerWatts { get; set; }
        public double Price { get; set; }

        public KitchenAppliance(string model, int watts, double price)
        {
            ModelName = model;
            PowerWatts = watts;
            Price = price;
        }

        public abstract void Cook();

        public virtual void Preheat()
        {
            Console.WriteLine($"{ModelName}: No preheating required.");
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"\nModel: {ModelName}");
            Console.WriteLine($"Power: {PowerWatts}W");
            Console.WriteLine($"Price: ${Price}");
        }
    }

    class Microwave : KitchenAppliance, ITimer
    {
        public Microwave(string model, int watts, double price) : base(model, watts, price)
        {
        }
        public override void Cook()
        {
            Console.WriteLine($"{ModelName}: Heating food.");
        }

        public void SetTimer(int minutes)
        {
            Console.WriteLine($"{ModelName}: Timer set for {minutes} minutes.");
        }
    }

    class EletricOven : KitchenAppliance, ITimer, ISmart
    {
        public EletricOven(string model, int watts, double price) : base(model, watts, price)
        {
        }

        public void ConnectWifi()
        {
            Console.WriteLine($"{ModelName} connected to wifi successfully"); ;
        }

        public override void Cook()
        {
            Console.WriteLine($"{ModelName}: Baking food.");
        }

        public void SetTimer(int minutes)
        {
            Console.WriteLine($"{ModelName}: Timer set for {minutes} minutes.");
        }

        public override void Preheat()
        {
            Console.WriteLine($"{ModelName} requires preheating for 5mins at 180 degree");
        }

    }

    class AirFryer : KitchenAppliance, ITimer, ISmart
    {
        public AirFryer(string model, int watts, double price) : base(model, watts, price)
        {
        }

        public override void Preheat()
        {
            Console.WriteLine($"{ModelName} preheating at 180 degree for 5mins");
        }

        public void ConnectWifi()
        {
            Console.WriteLine($"{ModelName} connected to wifi successfully"); ;
        }

        public override void Cook()
        {
            Console.WriteLine($"{ModelName}: frying food.");
        }

        public void SetTimer(int minutes)
        {
            Console.WriteLine($"{ModelName}: Timer set for {minutes} minutes.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<KitchenAppliance> appliances = new List<KitchenAppliance>()
            {
                new Microwave("MW-100", 1200, 200),
                new EletricOven("OV-Pro", 2200, 600),
                new AirFryer("AF-X", 1500, 180),
            };

            foreach (KitchenAppliance item in appliances)
            {
                item.DisplayInfo();
                item.Preheat();
                item.Cook();

                if (item is ITimer)
                {
                    ITimer timerDevice = (ITimer)item;
                    timerDevice.SetTimer(10);
                }

                if (item is ISmart)
                {
                    ISmart smartDevice = (ISmart)item;
                    smartDevice.ConnectWifi();
                }
            }
        }
    }
}
