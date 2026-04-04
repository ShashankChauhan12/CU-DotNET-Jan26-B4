using Microsoft.EntityFrameworkCore;
using Travel.API.Data;
using Travel.API.Models;

namespace Travel.API.Repositories
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly TravelAPIContext _context;

        public DestinationRepository(TravelAPIContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Destination>> GetAllAsync()
        {
            return await _context.Destination.ToListAsync();
        }

        public async Task<Destination?> GetByIdAsync(int id)
        {
            return await _context.Destination.FindAsync(id);
        }

        public async Task<Destination> AddAsync(Destination destination)
        {
            _context.Destination.Add(destination);
            await _context.SaveChangesAsync();
            return destination;
        }

        public async Task UpdateAsync(Destination destination)
        {
            _context.Destination.Update(destination);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dest = await _context.Destination.FindAsync(id);
            if (dest != null)
            {
                _context.Destination.Remove(dest);
                await _context.SaveChangesAsync();
            }
        }
    }
}
