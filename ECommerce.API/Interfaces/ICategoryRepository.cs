using ECommerce.API.Models;

namespace ECommerce.API.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> PostAsync(Category image);
        Task<Category> PutAsync(int id, Category image);
        Task DeleteAsync(int id);
    }
}
