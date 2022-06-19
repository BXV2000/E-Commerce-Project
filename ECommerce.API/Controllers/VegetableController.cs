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
                if (!getVegetable.Any()) return NotFound("Vegetable Empty");
                return Ok(getVegetable.Where(vegetable => vegetable.IsDelete == false));
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
            try
            {
                var getVegetable = _context.Vegetables.Find(id);
                if (getVegetable == null || getVegetable.IsDeleted == true) return NotFound("Vegetable not found :(");
                return Ok(new VegetableModel
                {
                    Id = getVegetable.Id,
                    CategoryId = getVegetable.CategoryId,
                    Name = getVegetable.Name,
                    MFGDate = getVegetable.MFGDate,
                    EXPDate = getVegetable.EXPDate,
                    Price = getVegetable.Price,
                    Stock = getVegetable.Stock,
                    IsDelete = getVegetable.IsDeleted
                });
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        //Post Vegetable
        [HttpPost]
        public IActionResult Post(VegetableModel info)
        {
            try
            {
                var checkCategory = _context.Categories.Find(info.CategoryId);
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
                if (checkCategory == null || checkCategory.IsDeleted==true) return NotFound("Category not found");
                _context.Vegetables.Add(vegetable);
                _context.SaveChanges();
                return Ok(new VegetableModel
                {
                    Id = vegetable.Id,
                    CategoryId = vegetable.CategoryId,
                    Name = vegetable.Name,
                    MFGDate = vegetable.MFGDate,
                    EXPDate = vegetable.EXPDate,
                    Price = vegetable.Price,
                    Stock = vegetable.Stock,
                    IsDelete = vegetable.IsDeleted
                });
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        //Update Vegetable
        [HttpPut("{id}")]
        public IActionResult Put(int id, VegetableModel info)
        {
            try
            {
                using (var context = new ECommerceDbContext())
                {
                    var vegetable = context.Vegetables.Find(id);
                    var checkCategory = context.Categories.Find(info.CategoryId);
                    if (vegetable == null || vegetable.IsDeleted == true ) return NotFound("Vegetable not found");
                    if (checkCategory == null || checkCategory.IsDeleted == true) return NotFound("Category not found");
                    vegetable.CategoryId = info.CategoryId;
                    vegetable.Name = info.Name;
                    vegetable.MFGDate = info.MFGDate;
                    vegetable.EXPDate = info.EXPDate; 
                    vegetable.Price = info.Price; 
                    vegetable.Stock = info.Stock; 
                    context.Entry(vegetable).State = EntityState.Modified;
                    context.SaveChanges();
                    return Ok(new VegetableModel
                    {
                        Id = vegetable.Id,
                        CategoryId = vegetable.CategoryId,
                        Name = vegetable.Name,
                        MFGDate = vegetable.MFGDate,
                        EXPDate = vegetable.EXPDate,
                        Price = vegetable.Price,
                        Stock = vegetable.Stock,
                        IsDelete = vegetable.IsDeleted
                    });
                }
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
