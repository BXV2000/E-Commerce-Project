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
        public IActionResult Get()
        {
            try
            {
                var getCategory = _context.Categories.Select(category => new CategoryModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                }).ToList();
                if (!getCategory.Any()) return NotFound("Category Empty");
                return Ok(getCategory.Where(category=> category.IsDelete==false));
            }
            catch
            {
                return BadRequest("Something went wrong");
            }

        }

        //Get one Category
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var getCategory = _context.Categories.Find(id);
                if (getCategory == null || getCategory.IsDeleted == true) return NotFound("Category not found :(");
                return Ok(new CategoryModel
                {
                    Id = getCategory.Id,
                    Name = getCategory.Name,
                    Description = getCategory.Description,
                });
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        //Post Category
        [HttpPost]
        public IActionResult Post(CategoryModel info)
        {
            try
            {
                var category = new Category
                {
                    Name = info.Name,
                    Description = info.Description,
                };
                _context.Categories.Add(category);
                _context.SaveChanges();
                return Ok(new CategoryModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                });
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        //Update Category
        [HttpPut("{id}")]
        public IActionResult Put(int id, CategoryModel info)
        {
            try
            {
                using (var context = new ECommerceDbContext())
                {
                    var category = context.Categories.Find(id);
                    if (category == null || category.IsDeleted == true) return NotFound("Category not found :(");
                    category.Name = info.Name;
                    category.Description = info.Description;
                    context.Entry(category).State = EntityState.Modified;
                    context.SaveChanges();
                    return Ok(new CategoryModel
                    {
                        Id = category.Id,
                        Name = category.Name,
                        Description = category.Description,
                    });
                }
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        //Delete Category
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                using (var context = new ECommerceDbContext())
                {
                    var category = context.Categories.Find(id);
                    if (category == null || category.IsDeleted == true) return NotFound("Category not found :(");
                    category.IsDeleted = true;
                    context.Entry(category).State = EntityState.Modified;
                    context.SaveChanges();
                    return Ok(new CategoryModel
                    {
                        Id = category.Id,
                        Name = category.Name,
                        Description = category.Description,
                    });
                }
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
