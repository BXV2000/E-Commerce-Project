using ECommerce.SharedDataModels;
using Refit;

namespace ECommerce.Customer.Services
{
    public interface IVegetableService
    {
        // Get all images
        [Get("/Image")]
        Task<List<VegetableDTO>> GetVegetables();

        // Get image by id
        [Get("/Image/{id}")]
        Task<VegetableDTO> GetVegetable(int id);

        // Add image
        [Post("/Image")]
        Task CreateImage([Body] VegetableDTO image);

        //// Update image
        //[Put("/Image/{id}")]
        //Task UpdateImage(int id, [Body] ImageDTO image);

        //// Delete image
        //[Delete("/Image/{id}")]
        //Task DeleteImage(int id);
    }
}
