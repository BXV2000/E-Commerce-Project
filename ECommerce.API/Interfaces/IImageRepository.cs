using ECommerce.API.Models;

namespace ECommerce.API.Interfaces
{
    public interface IImageRepository
    {
        Task<List<Image>> GetAsync();
        Task<Image> GetByIdAsync(int id);
        Task<Image> PostAsync(Image image);
        Task<Image> PutAsync(int id,Image image);
        Task DeleteAsync(int id);
    }
}
