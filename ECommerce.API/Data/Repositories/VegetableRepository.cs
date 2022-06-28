using ECommerce.API.Interfaces;
using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Data.Repositories
{
    public class VegetableRepository : IVegetableRepository
    {
        private readonly ECommerceDbContext _context;

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Vegetable>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Vegetable> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Vegetable> PostAsync(Vegetable image)
        {
            throw new NotImplementedException();
        }

        public Task<Vegetable> PutAsync(int id, Vegetable image)
        {
            throw new NotImplementedException();
        }
    }
}
