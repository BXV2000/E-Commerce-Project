using ECommerce.API.DTOs;
using Refit;

namespace ECommerce.Customer.Services
{
    public interface IImageService
    {
        // Get all images
        [Get("/Image")]
        Task<List<ImageReadDTO>> GetImages();

        // Get image by id
        [Get("/Image/{id}")]
        Task<ImageReadDTO> GetImage(int id);

        // Add image
        [Post("/Image")]
        Task CreateImage([Body] ImageCreateUpdateDTO image);

        // Update image
        [Put("/Image/{id}")]
        Task UpdateImage(int id, [Body] ImageCreateUpdateDTO image);

        // Delete image
        [Delete("/Image/{id}")]
        Task DeleteImage(int id);
    }
}
