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
        public async Task<ActionResult<List<Category>>> GetAllCategory()
        {
            return Ok(await _context.Categories.ToListAsync());  
        }

        //Get one Category
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetOneCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return BadRequest("Category not found :(");
            return Ok(category);    
        }

        //Post Category
        [HttpPost]
        public async Task<ActionResult<List<Category>>> PostCategory(Category info)
        {
            _context.Categories.Add(info);
            await _context.SaveChangesAsync();
            return Ok(await _context.Categories.ToListAsync());
        }


    }
}
