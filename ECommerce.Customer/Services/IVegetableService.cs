using ECommerce.SharedDataModels;
using Refit;

namespace ECommerce.Customer.Services
{
    public interface IVegetableService
    {
        // Get all images
        [Get("/Vegetable")]
        Task<List<VegetableDTO>> GetVegetables();

        // Get image by id
        [Get("/Vegetable/{id}")]
        Task<VegetableDTO> GetVegetable(int id);

        // Add image
        [Post("/Vegetable")]
        Task CreateImage([Body] VegetableDTO image);

        //// Update image
        //[Put("/Vegetable/{id}")]
        //Task UpdateImage(int id, [Body] ImageDTO image);

        //// Delete image
        //[Delete("/Vegetable/{id}")]
        //Task DeleteImage(int id);
    }
}
