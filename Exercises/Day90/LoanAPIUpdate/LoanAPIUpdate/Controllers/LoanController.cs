using LoanAPIUpdate.Common;
using LoanAPIUpdate.DTOs;
using LoanAPIUpdate.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoanAPIUpdate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _service;

        public LoanController(ILoanService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(ApiResponse<object>.SuccessResponse(data, "All loans fetched"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _service.GetByIdAsync(id);
            return Ok(ApiResponse<object>.SuccessResponse(data, "Loan fetched"));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLoanDto dto)
        {
            var data = await _service.CreateAsync(dto);
            return Ok(ApiResponse<object>.SuccessResponse(data, "Loan created"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok(ApiResponse<string>.SuccessResponse("", "Loan deleted"));
        }
    }
}
