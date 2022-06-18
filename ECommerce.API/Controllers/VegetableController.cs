using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerce.API.Models;
using ECommerce.API.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VegetableController : ControllerBase
    {
        private readonly ECommerceDbContext _context;

        public VegetableController(ECommerceDbContext context)
        {
            _context = context;
        }

        //Get all Vegetable
        [HttpGet]
        public async Task<ActionResult<List<Vegetable>>> GetAllVegetable()
        {
            return Ok(await _context.Vegetables.ToListAsync());  
        }

        //Get one Vegetable
        [HttpGet("{id}")]
        public async Task<ActionResult<Vegetable>> GetOneVegetable(int id)
        {
            var Vegetable = await _context.Vegetables.FindAsync(id);
            if (Vegetable == null) return BadRequest("Vegetable not found :(");
            return Ok(Vegetable);    
        }

        //Post Vegetable
        [HttpPost]
        public async Task<ActionResult<List<Vegetable>>> PostVegetable(Vegetable info)
        {
            _context.Vegetables.Add(info);
            await _context.SaveChangesAsync();
            return Ok(await _context.Vegetables.ToListAsync());
        }


    }
}
