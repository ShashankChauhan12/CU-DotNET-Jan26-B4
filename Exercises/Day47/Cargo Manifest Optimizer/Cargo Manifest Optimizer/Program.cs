namespace Cargo_Manifest_Optimizer
{
    public class Item
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Category { get; set; }

        public Item(string name, double weight, string category)
        {
            Name = name;
            Weight = weight;
            Category = category;
        }
    }

    public class Container
    {
        public string ContainerID { get; set; }
        public List<Item> Items { get; set; }

        public Container(string id, List<Item> items)
        {
            ContainerID = id;
            Items = items;
        }
    }

    public class CargoManager
    {
        private List<List<Container>> cargoBay;

        public CargoManager(List<List<Container>> cargo)
        {
            cargoBay = cargo;
        }

        public List<string> FindHeavyContainers(double weightThreshold)
        {
            return cargoBay
                .Where(r => r != null)
                .SelectMany(r => r)
                .Where(c => c != null && c.Items != null && c.Items.Sum(i => i.Weight) > weightThreshold)
                .Select(c => c.ContainerID)
                .ToList();
        }

        public Dictionary<string, int> GetItemCountsByCategory()
        {
            return cargoBay
                .Where(r => r != null)
                .SelectMany(r => r)
                .Where(c => c != null && c.Items != null)
                .SelectMany(c => c.Items)
                .GroupBy(i => i.Category)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public List<Item> FlattenAndSortShipment()
        {
            return cargoBay
                .Where(r => r != null)
                .SelectMany(r => r)
                .Where(c => c != null && c.Items != null)
                .SelectMany(c => c.Items)
                .GroupBy(i => i.Name)
                .Select(g => g.First())
                .OrderBy(i => i.Category)
                .ThenByDescending(i => i.Weight)
                .ToList();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var cargoBay = new List<List<Container>>
        {
            new List<Container>
            {
                new Container("C001", new List<Item>
                {
                    new Item("Laptop", 2.5, "Tech"),
                    new Item("Monitor", 5.0, "Tech"),
                    new Item("Smartphone", 0.5, "Tech")
                }),
                new Container("C104", new List<Item>
                {
                    new Item("Server Rack", 45.0, "Tech"),
                    new Item("Cables", 1.2, "Tech")
                })
            },

            new List<Container>
            {
                new Container("C002", new List<Item>
                {
                    new Item("Apple", 0.2, "Food"),
                    new Item("Banana", 0.2, "Food"),
                    new Item("Milk", 1.0, "Food")
                }),
                new Container("C003", new List<Item>
                {
                    new Item("Table", 15.0, "Furniture"),
                    new Item("Chair", 7.5, "Furniture")
                })
            },

            new List<Container>
            {
                new Container("C205", new List<Item>
                {
                    new Item("Vase", 3.0, "Decor"),
                    new Item("Mirror", 12.0, "Decor")
                }),
                new Container("C206", new List<Item>())
            },

            new List<Container>()
        };

            var manager = new CargoManager(cargoBay);

            var heavyContainers = manager.FindHeavyContainers(20);
            Console.WriteLine("Heavy Containers:");
            foreach (var id in heavyContainers)
                Console.WriteLine(id);

            var categoryCounts = manager.GetItemCountsByCategory();
            Console.WriteLine("\nItem Counts by Category:");
            foreach (var kv in categoryCounts)
                Console.WriteLine(kv.Key + ": " + kv.Value);

            var sortedItems = manager.FlattenAndSortShipment();
            Console.WriteLine("\nFlattened and Sorted Items:");
            foreach (var item in sortedItems)
                Console.WriteLine(item.Name + " | " + item.Category + " | " + item.Weight);
        }
    }
}