using ECommerce.API.Interfaces;
using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Data.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly ECommerceDbContext _context;

        public RatingRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            var rating = await _context.Ratings.FirstOrDefaultAsync(c => c.Id == id);
            rating.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Rating>> GetAsync()
        {
            return await _context.Ratings.Where(r => r.IsDeleted == false).ToListAsync();
        }

        public async Task<Rating> GetByIdAsync(int id)
        {
            return await _context.Ratings.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Rating> PostAsync(Rating rating)
        {
            _context.Ratings.Add(rating);
            await _context.SaveChangesAsync();
            return rating;
        }

        public async Task<Rating> PutAsync(int id, Rating rating)
        {
            var getRating = await _context.Ratings.FirstOrDefaultAsync(r => r.Id == id);
            getRating.RatingNumber = rating.RatingNumber;
            await _context.SaveChangesAsync();
            return getRating;
        }
    }
}
