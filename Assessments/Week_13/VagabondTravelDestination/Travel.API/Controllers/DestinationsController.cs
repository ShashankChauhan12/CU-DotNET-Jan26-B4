using Microsoft.AspNetCore.Mvc;
using Travel.API.Exceptions;
using Travel.API.Models;
using Travel.API.Repositories;

namespace Travel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        private readonly IDestinationRepository _repo;

        public DestinationsController(IDestinationRepository repo)
        {
            _repo = repo;
        }

        // ✅ GET: api/destinations
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var destinations = await _repo.GetAllAsync();
            return Ok(destinations);
        }

        // ✅ GET: api/destinations/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var destination = await _repo.GetByIdAsync(id);

            if (destination == null)
                throw new DestinationNotFoundException(id);   // ✔ Assessment requirement

            return Ok(destination);
        }

        // ✅ POST: api/destinations
        [HttpPost]
        public async Task<IActionResult> Create(Destination destination)
        {
            var created = await _repo.AddAsync(destination);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // ✅ PUT: api/destinations/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Destination destination)
        {
            if (id != destination.Id)
                return BadRequest();

            var existing = await _repo.GetByIdAsync(id);

            if (existing == null)
                throw new DestinationNotFoundException(id);

            await _repo.UpdateAsync(destination);

            return NoContent();
        }

        // ✅ DELETE: api/destinations/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _repo.GetByIdAsync(id);

            if (existing == null)
                throw new DestinationNotFoundException(id);

            await _repo.DeleteAsync(id);

            return NoContent();
        }
    }
}