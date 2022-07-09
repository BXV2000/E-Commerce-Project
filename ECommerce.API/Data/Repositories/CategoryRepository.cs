using ECommerce.API.Interfaces;
using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ECommerceDbContext _context;

        public CategoryRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            category.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category> PostAsync(Category c)
        {
            _context.Categories.Add(c);
            await _context.SaveChangesAsync();
            return c;
        }

        public Task<Category> PutAsync(int id, Category c)
        {
            throw new NotImplementedException();
        }
    }
}
