using StudentDataLayer.Models;
using StudentDataLayer.Repositories;
using StudentDataLayer.Services;

namespace StudentDataLayer.UI
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Select Storage:");
            Console.WriteLine("1. In-Memory");
            Console.WriteLine("2. JSON File");

            var choice = Console.ReadLine();

            IStudentRepository repository;

            if (choice == "1")
                repository = new ListStudentRepository();
            else
                repository = new JsonStudentRepository();

            var service = new StudentService(repository);

            while (true)
            {
                Console.WriteLine("\n1. Add\n2. View\n3. Update\n4. Delete\n5. Exit");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Id: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Grade: ");
                        int grade = int.Parse(Console.ReadLine());

                        service.AddStudent(new Student { Id = id, Name = name, Grade = grade });
                        break;

                    case "2":
                        var students = service.GetAllStudents();
                        foreach (var s in students)
                            Console.WriteLine($"{s.Id} - {s.Name} - {s.Grade}");
                        break;

                    case "3":
                        Console.Write("Id to update: ");
                        int uid = int.Parse(Console.ReadLine());

                        Console.Write("New Name: ");
                        string newName = Console.ReadLine();

                        Console.Write("New Grade: ");
                        int newGrade = int.Parse(Console.ReadLine());

                        service.UpdateStudent(new Student { Id = uid, Name = newName, Grade = newGrade });
                        break;

                    case "4":
                        Console.Write("Id to delete: ");
                        int did = int.Parse(Console.ReadLine());

                        service.DeleteStudent(did);
                        break;

                    case "5":
                        return;
                }
            }
        }
    }
}
