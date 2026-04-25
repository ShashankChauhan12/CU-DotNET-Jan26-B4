using LoanAPIUpdate.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace LoanAPIUpdate.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Loan> Loans { get; set; }
        public DbSet<EMISchedule> EMISchedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasKey(x => x.LoanId);

                entity.Property(x => x.LoanType)
                      .HasMaxLength(50)
                      .IsRequired();

                entity.Property(x => x.Purpose)
                      .HasMaxLength(100);

                entity.Property(x => x.Status)
                      .HasMaxLength(20);
            });

            modelBuilder.Entity<EMISchedule>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(x => x.Loan)
                      .WithMany(x => x.EMISchedules)
                      .HasForeignKey(x => x.LoanId);
            });
        }
    }
}
