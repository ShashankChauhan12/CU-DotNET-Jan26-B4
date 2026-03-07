namespace Student_Performance_Analytics
{
    class Student
    {
        public int Id;
        public string Name;
        public string Class;
        public int Marks;
    }

    class Employee
    {
        public int Id;
        public string Name;
        public string Dept;
        public double Salary;
        public DateTime JoinDate;
    }

    class Product
    {
        public int Id;
        public string Name;
        public string Category;
        public double Price;
    }

    class Sale
    {
        public int ProductId;
        public int Qty;
    }

    class Book
    {
        public string Title;
        public string Author;
        public string Genre;
        public int Year;
        public double Price;
    }

    class Customer
    {
        public int Id;
        public string Name;
        public string City;
    }

    class Order
    {
        public int OrderId;
        public int CustomerId;
        public double Amount;
    }

    class Movie
    {
        public string Title;
        public string Genre;
        public double Rating;
        public int Year;
    }

    class Transaction
    {
        public int Acc;
        public double Amount;
        public string Type;
    }

    class CartItem
    {
        public string Name;
        public string Category;
        public double Price;
        public int Qty;
    }

    class User
    {
        public int Id;
        public string Name;
        public string Country;
    }

    class Post
    {
        public int UserId;
        public int Likes;
    }
    internal class Program
    {
        static void Main()
        {
            var students = new List<Student>
            {
                new Student{Id=1, Name="Amit", Class="10A", Marks=85},
                new Student{Id=2, Name="Neha", Class="10A", Marks=72},
                new Student{Id=3, Name="Rahul", Class="10B", Marks=90},
                new Student{Id=4, Name="Pooja", Class="10B", Marks=60},
                new Student{Id=5, Name="Kiran", Class="10A", Marks=95}
            };

            var top3 = students.OrderByDescending(s => s.Marks).Take(3);

            Console.WriteLine("Top 3 Students:");
            foreach (var s in top3)
                Console.WriteLine($"{s.Name}  {s.Marks}");


            // EMPLOYEES
            var employees = new List<Employee>
            {
                new Employee{Id=1, Name="Ravi", Dept="IT", Salary=80000, JoinDate=new DateTime(2019,1,10)},
                new Employee{Id=2, Name="Anita", Dept="HR", Salary=60000, JoinDate=new DateTime(2021,3,5)},
                new Employee{Id=3, Name="Suresh", Dept="IT", Salary=120000, JoinDate=new DateTime(2018,7,15)},
                new Employee{Id=4, Name="Meena", Dept="Finance", Salary=90000, JoinDate=new DateTime(2022,9,1)}
            };

            var deptCount = employees.GroupBy(e => e.Dept)
                                     .Select(g => new { Dept = g.Key, Count = g.Count() });

            Console.WriteLine("\nEmployees per Department:");
            foreach (var d in deptCount)
                Console.WriteLine($"{d.Dept} {d.Count}");


            // PRODUCTS AND SALES
            var products = new List<Product>
            {
                new Product{Id=1, Name="Laptop", Category="Electronics", Price=50000},
                new Product{Id=2, Name="Phone", Category="Electronics", Price=20000},
                new Product{Id=3, Name="Table", Category="Furniture", Price=5000}
            };

            var sales = new List<Sale>
            {
                new Sale{ProductId=1, Qty=10},
                new Sale{ProductId=2, Qty=20}
            };

            var revenue = from p in products
                          join s in sales on p.Id equals s.ProductId
                          select new { p.Name, Total = p.Price * s.Qty };

            Console.WriteLine("\nProduct Revenue:");
            foreach (var r in revenue)
                Console.WriteLine($"{r.Name} {r.Total}");


            var books = new List<Book>
            {
                new Book{Title="C# Basics", Author="John", Genre="Tech", Year=2018, Price=500},
                new Book{Title="Java Advanced", Author="Mike", Genre="Tech", Year=2016, Price=700},
                new Book{Title="History India", Author="Raj", Genre="History", Year=2019, Price=400}
            };

            var booksAfter2015 = books.Where(b => b.Year > 2015);

            Console.WriteLine("\nBooks after 2015:");
            foreach (var b in booksAfter2015)
                Console.WriteLine(b.Title);

            var customers = new List<Customer>
            {
                new Customer{Id=1, Name="Ajay", City="Delhi"},
                new Customer{Id=2, Name="Sunita", City="Mumbai"}
            };

            var orders = new List<Order>
            {
                new Order{OrderId=1, CustomerId=1, Amount=20000},
                new Order{OrderId=2, CustomerId=1, Amount=40000}
            };

            var totalOrders = orders.GroupBy(o => o.CustomerId)
                                    .Select(g => new { Customer = g.Key, Total = g.Sum(x => x.Amount) });

            Console.WriteLine("\nCustomer Spending:");
            foreach (var t in totalOrders)
                Console.WriteLine($"Customer {t.Customer} Total {t.Total}");


            var movies = new List<Movie>
            {
                new Movie{Title="Inception", Genre="SciFi", Rating=9, Year=2010},
                new Movie{Title="Avatar", Genre="SciFi", Rating=8.5, Year=2009},
                new Movie{Title="Titanic", Genre="Drama", Rating=8, Year=1997}
            };

            var highRated = movies.Where(m => m.Rating > 8);

            Console.WriteLine("\nHigh Rated Movies:");
            foreach (var m in highRated)
                Console.WriteLine(m.Title);


            var transactions = new List<Transaction>
            {
                new Transaction{Acc=101, Amount=5000, Type="Credit"},
                new Transaction{Acc=101, Amount=2000, Type="Debit"},
                new Transaction{Acc=102, Amount=10000, Type="Debit"}
            };

            var balance = transactions.GroupBy(t => t.Acc)
                                      .Select(g => new { Acc = g.Key, Total = g.Sum(x => x.Amount) });

            Console.WriteLine("\nAccount Balance:");
            foreach (var b in balance)
                Console.WriteLine($"{b.Acc} {b.Total}");


            var cart = new List<CartItem>
            {
                new CartItem{Name="TV", Category="Electronics", Price=30000, Qty=1},
                new CartItem{Name="Sofa", Category="Furniture", Price=15000, Qty=1}
            };

            var cartTotal = cart.Sum(c => c.Price * c.Qty);

            Console.WriteLine("\nCart Total: " + cartTotal);


            var users = new List<User>
            {
                new User{Id=1, Name="A", Country="India"},
                new User{Id=2, Name="B", Country="USA"}
            };

            var posts = new List<Post>
            {
                new Post{UserId=1, Likes=100},
                new Post{UserId=1, Likes=50}
            };

            var totalLikes = posts.GroupBy(p => p.UserId)
                                  .Select(g => new { User = g.Key, Likes = g.Sum(x => x.Likes) });

            Console.WriteLine("\nTotal Likes per User:");
            foreach (var l in totalLikes)
                Console.WriteLine($"{l.User} {l.Likes}");
        }
    }
}
