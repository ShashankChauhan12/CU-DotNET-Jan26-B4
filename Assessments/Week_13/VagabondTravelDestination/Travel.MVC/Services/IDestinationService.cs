using Travel.MVC.Models;

namespace Travel.MVC.Services
{
    public interface IDestinationService
    {
        Task<IEnumerable<Destination>> GetAllAsync();

    }
}
