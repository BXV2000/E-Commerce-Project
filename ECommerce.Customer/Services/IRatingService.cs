using ECommerce.SharedDataModels;
using Refit;

namespace ECommerce.Customer.Services
{
    public interface IRatingService
    {
        // Get all ratings
        [Get("/rating")]
        Task<List<RatingDTO>> GetRatings();

        //Get Rantings by Product Id
        [Get("/rating")]
        Task<List<RatingDTO>> GetRatingsByProductId(int id);

        // Get rating by id
        [Get("/rating/{id}")]
        Task<RatingDTO> GetRating(int id);

        // Add rating
        [Post("/rating")]
        Task CreateRating([Body] RatingDTO image);

        //// Update rating
        //[Put("/Vegetable/{id}")]
        //Task UpdateImage(int id, [Body] ImageDTO image);

        //// Delete rating
        //[Delete("/Vegetable/{id}")]
        //Task DeleteImage(int id);
    }
}
