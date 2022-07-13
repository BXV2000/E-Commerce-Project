using ECommerce.API.Interfaces;
using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Data.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly ECommerceDbContext _context;
        
        public ImageRepository( ECommerceDbContext context)
        {
            _context = context;

        }
        public async Task DeleteAsync(int id)
        {
            var image = await _context.Images.FirstOrDefaultAsync(image => image.Id == id);
            image.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Image>> GetAsync()
        {
            return await _context.Images.Where(image => image.IsDeleted == false).ToListAsync();
        }

        public async Task<Image> GetByIdAsync(int id)
        {
            return await _context.Images.FirstOrDefaultAsync(image => image.Id == id);
        }

        public async Task<Image> PostAsync(Image image)
        {
            _context.Images.Add(image);
            await _context.SaveChangesAsync();
            return image;
        }

        public async Task<Image> PutAsync(int id, Image image)
        {
            var getImage = await _context.Images.FirstOrDefaultAsync(image => image.Id == id);
            getImage.ImageName = image.ImageName;
            getImage.ImageURL = image.ImageURL;
            await _context.SaveChangesAsync();
            return getImage;
        }
    }
}
