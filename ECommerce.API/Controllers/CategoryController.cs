using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerce.API.Models;
using ECommerce.API.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ECommerceDbContext _context;

        public CategoryController(ECommerceDbContext context)
        {
            _context = context;
        }

        //Get all Category
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var category = await _context.Categories.Select(c => new CategoryModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                }).ToListAsync();
                if (category == null) return BadRequest("There is no category");
                return Ok(category);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }

        }

        //Get one Category
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null) return BadRequest("Category not found :(");
                return Ok(new CategoryModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    IsDelete = category.IsDeleted,
                });
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        //Post Category
        [HttpPost]
        public async Task<IActionResult> Post(CategoryModel info)
        {
            try
            {
                var category = new Category
                {
                    Name = info.Name,
                    Description = info.Description,
                };
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
                return Ok(await _context.Categories.ToListAsync());
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        //Put Category
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CategoryModel info)
        {
            try
            {
                Category updateCategory;
                using (var context = new ECommerceDbContext())
                {
                    updateCategory = context.Categories.Where(catergory => catergory.Id == id).FirstOrDefault();
                    updateCategory.Name = info.Name;
                    updateCategory.Description = info.Description;
                    context.Entry(updateCategory).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                }
                return Ok(new CategoryModel
                {
                    Id = updateCategory.Id,
                    Name = updateCategory.Name,
                    Description = updateCategory.Description,
                    IsDelete = updateCategory.IsDeleted,
                });
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        //Delete Category
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Category updateCategory;
                using (var context = new ECommerceDbContext())
                {
                    updateCategory = context.Categories.Where(catergory => catergory.Id == id).FirstOrDefault();
                    updateCategory.IsDeleted = true;
                    context.Entry(updateCategory).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                }
                return Ok(new CategoryModel
                {
                    Id = updateCategory.Id,
                    Name = updateCategory.Name,
                    Description = updateCategory.Description,
                    IsDelete = updateCategory.IsDeleted,
                });
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        public class CategoryModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public bool IsDelete { get; set; }
        }
    }
}
