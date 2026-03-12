namespace MarksMaintain
{
    class Student
    {
        public int StudId { get; set; }
        public string SName { get; set; }

        public Student(int id, string name)
        {
            StudId = id;
            SName = name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Student s)
                return StudId == s.StudId;
            return false;
        }

        public override int GetHashCode()
        {
            return StudId.GetHashCode();
        }
    }
    internal class Program
    {
        static void Main()
        {
            Dictionary<Student, int> students = new Dictionary<Student, int>();

            AddOrUpdate(students, new Student(1, "Rahul"), 70);
            AddOrUpdate(students, new Student(2, "Aman"), 80);
            AddOrUpdate(students, new Student(1, "Rahul"), 85);
            AddOrUpdate(students, new Student(2, "Aman"), 75);

            foreach (var item in students)
            {
                Console.WriteLine("ID: " + item.Key.StudId + ", Name: " + item.Key.SName + ", Marks: " + item.Value);
            }
        }

        static void AddOrUpdate(Dictionary<Student, int> dict, Student student, int marks)
        {
            foreach (var s in dict.Keys)
            {
                if (s.Equals(student))
                {
                    if (marks > dict[s])
                        dict[s] = marks;
                    return;
                }
            }

            dict.Add(student, marks);
        }
    }
}

