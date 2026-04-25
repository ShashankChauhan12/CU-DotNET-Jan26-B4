using LoanAPIUpdate.Data;
using LoanAPIUpdate.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanAPIUpdate.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly AppDbContext _context;

        public LoanRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Loan>> GetAllAsync()
        {
            return await _context.Loans
                .Include(x => x.EMISchedules)
                .ToListAsync();
        }

        public async Task<Loan?> GetByIdAsync(int id)
        {
            return await _context.Loans
                .Include(x => x.EMISchedules)
                .FirstOrDefaultAsync(x => x.LoanId == id);
        }

        public async Task<Loan> CreateAsync(Loan loan)
        {
            await _context.Loans.AddAsync(loan);
            await _context.SaveChangesAsync();
            return loan;
        }

        public async Task DeleteAsync(Loan loan)
        {
            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();
        }
    }
}
