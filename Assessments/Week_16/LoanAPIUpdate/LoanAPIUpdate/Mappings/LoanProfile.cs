using AutoMapper;
using LoanAPIUpdate.DTOs;
using LoanAPIUpdate.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LoanAPIUpdate.Mappings
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<Loan, LoanDto>();
            CreateMap<CreateLoanDto, Loan>();
        }
    }
}
