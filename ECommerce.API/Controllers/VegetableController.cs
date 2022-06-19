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
        public IActionResult Get()
        {
            try
            {
                var getVegetable = _context.Vegetables.Select(vegetable => new VegetableModel
                {
                    Id = vegetable.Id,
                    CategoryId = vegetable.CategoryId,
                    Name = vegetable.Name,
                    MFGDate = vegetable.MFGDate,
                    EXPDate = vegetable.EXPDate,
                    Price = vegetable.Price,
                    Stock = vegetable.Stock,
                    IsDelete = vegetable.IsDeleted
                }).ToList();
                if (getVegetable != null) return BadRequest("Vegetable Empty");
                return Ok( getVegetable);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        //Get one Vegetable
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Vegetable = await _context.Vegetables.FindAsync(id);
            if (Vegetable == null) return BadRequest("Vegetable not found :(");
            return Ok(Vegetable);    
        }

        //Post Vegetable
        [HttpPost]
        public IActionResult Post(VegetableModel info)
        {
            try
            {
                var checkCategory = _context.Categories;
                var vegetable = new Vegetable
                {
                    CategoryId = info.CategoryId,
                    Name = info.Name,
                    MFGDate = info.MFGDate,
                    EXPDate = info.EXPDate,
                    Price = info.Price,
                    Stock = info.Stock,
                };
                if (vegetable.CategoryId == 0) return BadRequest("Please input category ID");
                if (checkCategory.Find(info.CategoryId) == null) return BadRequest("Cannot find category ID");
                if (checkCategory.Find(info.CategoryId) != null && 
                    checkCategory.Where(catergory => catergory.Id == info.CategoryId).FirstOrDefault().IsDeleted == true) 
                    return BadRequest("Category Deleted");
                //_context.Vegetables.AddAsync(vegetable);
                //await _context.SaveChangesAsync();
                return Ok(_context.Vegetables.ToList());
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        public class VegetableModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int CategoryId { get; set; }
            public DateTime MFGDate { get; set; }
            public DateTime EXPDate { get; set; }
            public decimal Price { get; set; }
            public int Stock { get; set; }
            public bool IsDelete { get; set; }
        }

    }
}
