using Microsoft.AspNetCore.Mvc;
using StudentCourseManagement.Data;
using StudentCourseManagement.DTOs;
using StudentCourseManagement.Models;

namespace StudentCourseManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EnrollController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Enroll(EnrollDto dto)
        {
            var enrollment = new StudentCourse
            {
                StudentId = dto.StudentId,
                CourseId = dto.CourseId
            };

            _context.StudentCourses.Add(enrollment);
            _context.SaveChanges();

            return Ok("Student enrolled successfully");
        }
    }
}
