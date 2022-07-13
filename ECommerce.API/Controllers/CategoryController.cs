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
                return Ok(cateDTOs);
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

        //Put Category
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CategoryDTO info)
        {
            try
            {
                var cate = _mapper.Map<Category>(info);
                var putCate = await _category.PutAsync(id, cate);
                //var checkVegetable = _context.Vegetables.Find(info.VegetableId);
                //if (checkVegetable == null || checkVegetable.IsDeleted == true) return NotFound("Vegetable not found");
                var returnCate = _mapper.Map<CategoryDTO>(putCate);
                return Ok(returnCate);
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
                var checkCate = await _category.GetByIdAsync(id);
                if (checkCate == null || checkCate.IsDeleted == true) return NotFound("Category not found");
                await _category.DeleteAsync(id);
                return Ok("Category Deleted");
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }


    }
}
