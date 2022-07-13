using ECommerce.API.Models;

namespace ECommerce.API.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> PostAsync(User user);
        Task<User> PutAsync(int id, User user);
        Task DeleteAsync(int id);
    }
}
