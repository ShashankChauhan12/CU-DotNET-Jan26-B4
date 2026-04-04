using Microsoft.EntityFrameworkCore;
using StudentCourseManagement.Models;

namespace StudentCourseManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Student Config
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Students");

                entity.Property(s => s.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(s => s.Email)
                      .IsRequired();

                entity.HasIndex(s => s.Email)
                      .IsUnique();
            });

            // Course Config
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Courses");

                entity.Property(c => c.Title)
                      .IsRequired();
            });

            // Many-to-Many Config
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);
        }
    }
}
