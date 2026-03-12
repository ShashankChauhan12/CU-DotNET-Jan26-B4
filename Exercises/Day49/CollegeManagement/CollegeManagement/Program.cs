namespace CollegeManagement
{
    internal class Program
    {
        class CollageManagement
        {
            Dictionary<string, Dictionary<string, int>> studentRecords = new Dictionary<string, Dictionary<string, int>>();

            Dictionary<string, LinkedList<KeyValuePair<string, int>>> studentSubjectsOrder = new Dictionary<string, LinkedList<KeyValuePair<string, int>>>();


            Dictionary<string, Dictionary<string, int>> subjectsRecords = new Dictionary<string, Dictionary<string, int>>();

            Dictionary<string, LinkedList<KeyValuePair<string, int>>> subjectsStudentsOrder = new Dictionary<string, LinkedList<KeyValuePair<string, int>>>();


            public int AddStudent(string studentId, string subject, int marks)
            {
                if (!studentRecords.ContainsKey(studentId))
                {
                    studentRecords[studentId] = new Dictionary<string, int>();
                }

                if (!studentRecords[studentId].ContainsKey(subject))
                {
                    studentRecords[studentId][subject] = marks;
                }
                else
                {
                    if (marks > studentRecords[studentId][subject])
                    {
                        studentRecords[studentId][subject] = marks;
                    }
                }

                if (!subjectsRecords.ContainsKey(subject))
                {
                    subjectsRecords[subject] = new Dictionary<string, int>();
                }

                if (!subjectsRecords[subject].ContainsKey(studentId))
                {
                    subjectsRecords[subject][studentId] = marks;
                }
                else
                {
                    if (marks > subjectsRecords[subject][studentId])
                    {
                        subjectsRecords[subject][studentId] = marks;
                    }
                }

                return 1;
            }


            public int RemoveStudent(string studentId)
            {
                if (!studentRecords.ContainsKey(studentId))
                    return 0;

                foreach (var sub in studentRecords[studentId])
                {
                    if (subjectsRecords.ContainsKey(sub.Key))
                    {
                        subjectsRecords[sub.Key].Remove(studentId);
                    }
                }

                studentRecords.Remove(studentId);
                return 1;
            }


            public string TopStudent(string subject)
            {
                if (!subjectsRecords.ContainsKey(subject))
                    return "";

                int max = -1;

                foreach (var s in subjectsRecords[subject])
                {
                    if (s.Value > max)
                    {
                        max = s.Value;
                    }
                }

                string result = "";

                foreach (var s in subjectsRecords[subject])
                {
                    if (s.Value == max)
                    {
                        result += s.Key + " " + s.Value + "\n";
                    }
                }

                return result;
            }


            public string Result()
            {
                string result = "";

                foreach (var student in studentRecords)
                {
                    int sum = 0;
                    int count = 0;

                    foreach (var sub in student.Value)
                    {
                        sum += sub.Value;
                        count++;
                    }

                    double avg = (double)sum / count;
                    result += student.Key + " " + avg.ToString("F2") + "\n";
                }

                return result;
            }
        }


        public static void Main()
        {
            CollageManagement cm = new CollageManagement();

            cm.AddStudent("S1", "Math", 80);
            cm.AddStudent("S2", "Math", 90);
            cm.AddStudent("S3", "Math", 90);
            cm.AddStudent("S1", "Phy", 90);

            Console.Write(cm.TopStudent("Math"));

            Console.Write(cm.Result());

            cm.RemoveStudent("S1");
        }
    }
}
