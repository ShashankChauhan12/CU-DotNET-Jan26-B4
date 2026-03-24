using StudentDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudentDataLayer.Repositories
{
    internal class JsonStudentRepository:IStudentRepository
    {
        private readonly string filePath = "../../../studentsData.json";

        private List<Student> LoadData()
        {
            if (!File.Exists(filePath))
                return new List<Student>();

            string json = File.ReadAllText(filePath);
            var students = JsonSerializer.Deserialize<List<Student>>(json);
            return students ?? new();
        }

        private void SaveData(List<Student> students)
        {
            string json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public List<Student> GetAll() => LoadData();

        public Student GetById(int id) => LoadData().FirstOrDefault(s => s.Id == id);

        public void Add(Student student)
        {
            var students = LoadData();
            students.Add(student);
            SaveData(students);
        }

        public void Update(Student student)
        {
            var students = LoadData();
            var existing = students.FirstOrDefault(s => s.Id == student.Id);

            if (existing != null) 
            {
                existing.Name = student.Name;
                existing.Grade = student.Grade;
                SaveData(students);
            }
        }

        public void Delete(int id)
        {
            var students = LoadData();
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student != null)
            {
                students.Remove(student);
                SaveData(students);
            }
        }
    }
}
