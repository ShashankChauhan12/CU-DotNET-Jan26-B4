using LoanAPIUpdate.DTOs;
using LoanAPIUpdate.Validators;

namespace Loan.Test
{
    public class ValidatorTests
    {
        private readonly CreateLoanValidator _validator = new();

        [Theory]
        [InlineData(100078)]
        [InlineData(500000)]
        public void Valid_Amount_Should_Pass(double amount)
        {
            var dto = new CreateLoanDto
            {
                UserId = 1,
                Amount = amount,
                LoanType = "personal",
                TermInMonths = 12,
                Purpose = "Test"
            };

            var result = _validator.Validate(dto);

            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData(-100)]
        [InlineData(0)]
        public void Invalid_Amount_Should_Fail(double amount)
        {
            var dto = new CreateLoanDto
            {
                UserId = 1,
                Amount = amount,
                LoanType = "personal",
                TermInMonths = 12,
                Purpose = "Test"
            };

            var result = _validator.Validate(dto);

            Assert.False(result.IsValid);
        }
    }
}