﻿using ECommerce.API.Interfaces;
using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Data.Repositories
{
    public class VegetableRepository : IVegetableRepository
    {
        private readonly ECommerceDbContext _context;

        public VegetableRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            var  vegetable = await _context.Vegetables.FirstOrDefaultAsync(vegie => vegie.Id == id);
            vegetable.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Vegetable>> GetAsync()
        {
            return await _context.Vegetables.ToListAsync();
        }

        public async Task<Vegetable> GetByIdAsync(int id)
        {
            return await _context.Vegetables.FirstOrDefaultAsync(image => image.Id == id);
        }

        public async Task<Vegetable> PostAsync(Vegetable vegetable)
        {
            _context.Vegetables.Add(vegetable);
            await _context.SaveChangesAsync();
            return vegetable;
        }

        public Task<Vegetable> PutAsync(int id, Vegetable vegetable)
        {
            throw new NotImplementedException();
        }
    }
}
