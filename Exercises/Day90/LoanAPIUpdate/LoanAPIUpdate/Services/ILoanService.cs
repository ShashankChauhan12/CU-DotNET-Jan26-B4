using LoanAPIUpdate.DTOs;

namespace LoanAPIUpdate.Services
{
    public interface ILoanService
    {
        Task<List<LoanDto>> GetAllAsync();
        Task<LoanDto> GetByIdAsync(int id);
        Task<LoanDto> CreateAsync(CreateLoanDto dto);
        Task DeleteAsync(int id);
    }
}
