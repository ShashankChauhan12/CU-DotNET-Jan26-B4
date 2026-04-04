using Microsoft.AspNetCore.Mvc;
using StudentCourseManagement.Data;
using StudentCourseManagement.DTOs;
using StudentCourseManagement.Models;

namespace StudentCourseManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Students.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null) return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create(StudentDto dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                Email = dto.Email,
                Age = dto.Age
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, StudentDto dto)
        {
            var student = _context.Students.Find(id);
            if (student == null) return NotFound();

            student.Name = dto.Name;
            student.Email = dto.Email;
            student.Age = dto.Age;

            _context.SaveChanges();

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null) return NotFound();

            _context.Students.Remove(student);
            _context.SaveChanges();

            return Ok();
        }
    }
}
