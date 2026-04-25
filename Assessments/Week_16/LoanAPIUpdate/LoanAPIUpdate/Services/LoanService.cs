using AutoMapper;
using LoanAPIUpdate.DTOs;
using LoanAPIUpdate.Exceptions;
using LoanAPIUpdate.Models;
using LoanAPIUpdate.Repositories;

namespace LoanAPIUpdate.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _repo;
        private readonly IMapper _mapper;

        public LoanService(ILoanRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<LoanDto>> GetAllAsync()
        {
            var loans = await _repo.GetAllAsync();
            return _mapper.Map<List<LoanDto>>(loans);
        }

        public async Task<LoanDto> GetByIdAsync(int id)
        {
            var loan = await _repo.GetByIdAsync(id);

            if (loan == null)
                throw new NotFoundException("Loan not found");

            return _mapper.Map<LoanDto>(loan);
        }

        public async Task<LoanDto> CreateAsync(CreateLoanDto dto)
        {
            var loan = _mapper.Map<Loan>(dto);

            loan.Status = "pending";
            loan.DocsVerified = false;
            loan.AppliedAt = DateTime.UtcNow;
            loan.UpdatedAt = DateTime.UtcNow;

            loan.InterestRate = dto.LoanType.ToLower() switch
            {
                "education" => 12,
                "house" => 7,
                _ => 10
            };

            double r = loan.InterestRate / 12 / 100;
            int n = loan.TermInMonths;
            double p = loan.Amount;

            loan.EMIAmount =
                p * r * Math.Pow(1 + r, n) /
                (Math.Pow(1 + r, n) - 1);

            loan.EMIAmount = Math.Round(loan.EMIAmount, 2);
            loan.TotalPayable = Math.Round(loan.EMIAmount * n, 2);

            await _repo.CreateAsync(loan);

            return _mapper.Map<LoanDto>(loan);
        }

        public async Task DeleteAsync(int id)
        {
            var loan = await _repo.GetByIdAsync(id);

            if (loan == null)
                throw new NotFoundException("Loan not found");

            await _repo.DeleteAsync(loan);
        }
    }
}
