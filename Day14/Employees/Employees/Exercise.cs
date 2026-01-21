using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSLearning
{
    class Employee
    {
        private int id;

        public void setId(int a)
        {
            id = a;
        }
        public void getId()
        {
            Console.WriteLine($"{id}");
        }
        public string Name { get; set; }= string.Empty;

        private string department=string.Empty;

        public string Department
        {
            get { return department; }
            set { 
                if(value=="Account" || value=="Sales" || value=="IT")
                    department = value;
                else
                    Console.WriteLine("Invalid department input.");
            }
        }

        private int salary;

        public int Salary
        {
            get { return salary; }
            set { 
                if(value>=50000 && value <= 90000)
                    salary = value;
                else
                    Console.WriteLine("Invalid salary input. It should be in range of 50,000 to 90,000");

            }
        }

        public void Display()
        {
            Console.WriteLine($"Id: {id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Department: {Department}");
            Console.WriteLine($"Salary {Salary}");
        }


    }
    internal class Exercise
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee();
            e1.setId(22);
            e1.getId();
            e1.Name = "Shashank";
            e1.Department = "Consulting";
            e1.Salary = 60000;
            e1.Display();
        }
     }  
}









