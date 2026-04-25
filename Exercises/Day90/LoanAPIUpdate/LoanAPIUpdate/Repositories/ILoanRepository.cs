using LoanAPIUpdate.Models;

namespace LoanAPIUpdate.Repositories
{
    public interface ILoanRepository
    {
        Task<List<Loan>> GetAllAsync();
        Task<Loan?> GetByIdAsync(int id);
        Task<Loan> CreateAsync(Loan loan);
        Task DeleteAsync(Loan loan);
    }
}
