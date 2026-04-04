using Microsoft.AspNetCore.Mvc;

namespace StudentCourseManagement.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using StudentCourseManagement.Data;
    using StudentCourseManagement.DTOs;
    using StudentCourseManagement.Models;

    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CoursesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/courses
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Courses.ToList());
        }

        // GET: api/courses/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
                return NotFound();

            return Ok(course);
        }

        // POST: api/courses
        [HttpPost]
        public IActionResult Create(CourseDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var course = new Course
            {
                Title = dto.Title,
                Credits = dto.Credits
            };

            _context.Courses.Add(course);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = course.Id }, course);
        }

        // PUT: api/courses/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, CourseDto dto)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
                return NotFound();

            course.Title = dto.Title;
            course.Credits = dto.Credits;

            _context.SaveChanges();

            return Ok(course);
        }

        // DELETE: api/courses/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
                return NotFound();

            _context.Courses.Remove(course);
            _context.SaveChanges();

            return Ok("Course deleted");
        }
    }
}
