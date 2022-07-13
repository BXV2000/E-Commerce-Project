using ECommerce.API.Models;

namespace ECommerce.API.Interfaces
{
    public interface IRatingRepository
    {
        Task<List<Rating>> GetAsync();
        Task<Rating> GetByIdAsync(int id);
        Task<Rating> PostAsync(Rating rating);
        Task<Rating> PutAsync(int id, Rating rating);
        Task DeleteAsync(int id);
    }

}
