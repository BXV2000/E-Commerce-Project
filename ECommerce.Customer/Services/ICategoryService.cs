using ECommerce.SharedDataModels;
using Refit;

namespace ECommerce.Customer.Services
{
    public interface ICategoryService
    {
        // Get all categories
        [Get("/Category")]
        Task<List<CategoryDTO>> GetCategories();

        // Get image by id
        [Get("/Category/{id}")]
        Task<CategoryDTO> GetCategory(int id);

        // Add image
        //[Post("/Vegetable")]
        //Task CreateImage([Body] VegetableDTO image);

        //// Update image
        //[Put("/Vegetable/{id}")]
        //Task UpdateImage(int id, [Body] ImageDTO image);

        //// Delete image
        //[Delete("/Vegetable/{id}")]
        //Task DeleteImage(int id);
    }
}
