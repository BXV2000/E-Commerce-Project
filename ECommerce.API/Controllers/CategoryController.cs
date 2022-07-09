using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerce.API.Models;
using ECommerce.API.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ECommerce.API.Interfaces;
using ECommerce.SharedDataModels;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _category;

        public CategoryController(ICategoryRepository category, IMapper mapper)
        {
            _category = category;
            _mapper = mapper;
        }

        // Get all Category
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var getCates = await _category.GetAsync();
                if (!getCates.Any()) return NotFound("Category Empty");
                var cateDTOs = _mapper.Map<List<CategoryDTO>>(getCates);
                return Ok(cateDTOs.Where(image => image.IsDeleted == false));
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
                var getCate = await _category.GetByIdAsync(id);
                if (getCate == null || getCate.IsDeleted == true) return NotFound("Category not found :(");
                var cateDTO = _mapper.Map<CategoryDTO>(getCate);
                return Ok(cateDTO);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        //Post Category
        [HttpPost]
        public async Task<IActionResult> Post(CategoryDTO info)
        {
            try
            {
                var createCate = _mapper.Map<Category>(info);
                var cate = await _category.PostAsync(createCate);
                var returnCate = _mapper.Map<CategoryDTO>(cate);
                return Ok(returnCate);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }

        }

        //        //Put Category
        //        [HttpPut("{id}")]
        //        public IActionResult Put(int id, CategoryModel info)
        //        {
        //            try
        //            {
        //                Category updateCategory;
        //                using (var context = new ECommerceDbContext())
        //                {
        //                    var category = context.Categories.Find(id);
        //                    if (category == null || category.IsDeleted == true) return NotFound("Category not found :(");
        //                    category.Name = info.Name;
        //                    category.Description = info.Description;
        //                    context.Entry(category).State = EntityState.Modified;
        //                    context.SaveChanges();
        //                    return Ok(new CategoryModel
        //                    {
        //                        Id = category.Id,
        //                        Name = category.Name,
        //                        Description = category.Description,
        //                    });
        //                }
        //            }
        //            catch
        //            {
        //                return BadRequest("Something went wrong");
        //            }
        //        }

        //        //Delete Category
        //        [HttpDelete("{id}")]
        //        public IActionResult Delete(int id)
        //        {
        //            try
        //            {
        //                using (var context = new ECommerceDbContext())
        //                {
        //                    var category = context.Categories.Find(id);
        //                    if (category == null || category.IsDeleted == true) return NotFound("Category not found :(");
        //                    category.IsDeleted = true;
        //                    context.Entry(category).State = EntityState.Modified;
        //                    context.SaveChanges();
        //                    return Ok($"Category with id = {id} was deleted ");
        //                }
        //            }
        //            catch
        //            {
        //                return BadRequest("Something went wrong");
        //            }
        //        }


    }
}
