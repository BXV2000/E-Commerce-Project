using ECommerce.API.Models;

namespace ECommerce.API.Interfaces
{
    public interface IVegetableRepository
    {
        Task<List<Vegetable>> GetAsync();
        Task<Vegetable> GetByIdAsync(int id);
        Task<Vegetable> PostAsync(Vegetable image);
        Task<Vegetable> PutAsync(int id,Vegetable image);
        Task DeleteAsync(int id);
    }
}
