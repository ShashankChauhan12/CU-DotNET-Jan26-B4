namespace BillingEngine
{

    class Patient
    {
        public string Name { get; set; }
        public decimal BaseFee { get; set; }


        public Patient(string nm,decimal bF)
        {
            Name=nm;
            BaseFee=bF;
        }
        public virtual decimal CalculateFinalBill()
        {
            return BaseFee;
        }
    }

    class Inpatient : Patient
    {
        public int DaysStayed { get; set; }
        public decimal DailyRate { get; set; }
        public Inpatient(string nm, decimal bF, int dS, decimal dR) : base(nm, bF)
        {
            DaysStayed = dS;
            DailyRate = dR;
        }

        public override decimal CalculateFinalBill()
        {
            return BaseFee + (DaysStayed * DailyRate);
        }
    }

    class Outpatient : Patient
    {
        public decimal ProcedureFee { get; set; }

        public Outpatient(string nm, decimal bF, decimal pF) : base(nm, bF)
        {
            ProcedureFee = pF;
        }

        public override decimal CalculateFinalBill()
        {
            return BaseFee + ProcedureFee;
        }
    }

    class EmergencyPatient : Patient
    {


        private int SeverityLevel;

        public int MyProperty
        {
            get { return SeverityLevel; }
            set { 
                if(value>0 && value<6)
                    SeverityLevel = value;
                else
                    Console.WriteLine("Wrong level");
            }
        }


        public EmergencyPatient(string nm, decimal bF, int sL) : base(nm, bF)
        {
            SeverityLevel = sL;
        }

        public override decimal CalculateFinalBill()
        {
            return BaseFee*SeverityLevel;
        }
    }

    class HospitalBilling
    {
        private List<Patient> patients = new List<Patient>();

        public void AddPatient(Patient p)
        {
            patients.Add(p);
        }
        public void GenerateDailyReport()
        {
            
            foreach (var p in patients)
            {
                decimal bill = p.CalculateFinalBill();
                Console.WriteLine($"Name:- {p.Name}    | Final Bill:- {bill.ToString("C2")}");
            }
        }

        public decimal CalculateTotalRevenue()
        {
            decimal total = 0;
            foreach (var item in patients)
            {
                total += item.CalculateFinalBill();
            }
            return total;
        }

        public int GetInpatientCount()
        {
            int count = 0;

            foreach (Patient p in patients)
            {
                if (p is Inpatient)
                {
                    count++;
                }
            }
            return count;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
           HospitalBilling hospital=new HospitalBilling();

            hospital.AddPatient(new Inpatient("Raman", 1700.00m, 5, 350.50m));
            hospital.AddPatient(new Outpatient("Suman", 1200.00m, 450.03m));
            hospital.AddPatient(new EmergencyPatient("Rohan", 2000.00m,2));

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("-----Daily Reports--------");
            Console.WriteLine();
            hospital.GenerateDailyReport();
            Console.WriteLine();


            Console.Write("-----Total Revenue--------");
            Console.WriteLine();
            Console.WriteLine($"Total revenue is:- {hospital.CalculateTotalRevenue().ToString("C2")}");
            Console.WriteLine();

            Console.Write("-----Inpatient Count--------");
            Console.WriteLine();
            Console.WriteLine($"Total revenue is:- {hospital.GetInpatientCount()}");
            hospital.GetInpatientCount();

        }
    }
}

