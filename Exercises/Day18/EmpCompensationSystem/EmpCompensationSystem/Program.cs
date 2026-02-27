namespace EmpCompensationSystem
{


    class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public decimal BasicSalary { get; set; }
        public int ExperienceInYears { get; set; }

        public Employee(int empId,string empName,decimal basSal,int expYear)
        {
            EmployeeId = empId;
            EmployeeName=empName;
            BasicSalary = basSal;
            ExperienceInYears=expYear;
        }


        public decimal CalculateAnnualSalary()
        {
            decimal annualSalary = BasicSalary * 12;
            return annualSalary;
        }

        public void DisplayEmployeeDetails()
        {
            Console.WriteLine($"EmployeeId:- {EmployeeId}  EmployeeName:- {EmployeeName}  BasicSalary:- {BasicSalary} Experience:- {ExperienceInYears} AnnualSalary:-v {CalculateAnnualSalary()} ");
        }
    }


    class PermanentEmployee : Employee
    {
        public PermanentEmployee(int empId, string empName, decimal basSal, int expYear)
            :base(empId,empName,basSal,expYear)
        {

        }

        public new decimal CalculateAnnualSalary() { 
        
            decimal houseAll=0.20m*BasicSalary;
            decimal specAll = 0.10m * BasicSalary;

            decimal annualSalary = (BasicSalary + houseAll + specAll) * 12;

            if (ExperienceInYears >= 5)
            {
                annualSalary += 50000;
            }

            return annualSalary;
        }
    }

    class ContractEmployee:Employee
    {

        public int ContractDurationInMonths { get; set; }
        public ContractEmployee(int empId, string empName, decimal basSal, int expYear,int cDM)
            : base(empId, empName, basSal, expYear)
        {
            ContractDurationInMonths = cDM;
        }

        public new decimal CalculateAnnualSalary()
        {

            decimal annualSalary = BasicSalary * 12;
            if(ContractDurationInMonths >= 12)
            {
                annualSalary += 30000;
            }
            return annualSalary;
        }
    }


    class InternEmployee : Employee
    {
        public InternEmployee(int empId, string empName, decimal basSal, int expYear)
            : base(empId, empName, basSal, expYear)
        {

        }

        public new decimal CalculateAnnualSalary()
        {
            decimal annualSalary= BasicSalary * 12;

            return annualSalary;
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new PermanentEmployee(101, "Nishant", 40000, 6);
            PermanentEmployee emp2 = new PermanentEmployee(102, "Naman", 40000, 6);
            Console.WriteLine(emp1.CalculateAnnualSalary());
            Console.WriteLine(emp2.CalculateAnnualSalary());
            emp1.DisplayEmployeeDetails();
            Console.WriteLine();

            Employee emp3 = new ContractEmployee(103, "Kunal", 30000, 3, 14);
            ContractEmployee emp4 = new ContractEmployee(104, "Naveen", 30000, 3, 14);
            Console.WriteLine(emp3.CalculateAnnualSalary());
            Console.WriteLine(emp4.CalculateAnnualSalary());
            Console.WriteLine();


            Employee emp5 = new InternEmployee(105, "Nishant", 15000, 1);
            InternEmployee emp6 = new InternEmployee(106, "Nishant 2.0", 15000, 1);
            Console.WriteLine(emp5.CalculateAnnualSalary());
            Console.WriteLine(emp6.CalculateAnnualSalary());
            Console.WriteLine();
            

        }
    }
}
