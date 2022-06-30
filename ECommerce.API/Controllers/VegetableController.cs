using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerce.API.Models;
using ECommerce.API.Data;
using Microsoft.EntityFrameworkCore;
using static ECommerce.API.Controllers.ImageController;
using AutoMapper;
using ECommerce.API.Interfaces;
using ECommerce.SharedDataModels;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VegetableController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVegetableRepository _vegetable;

        public VegetableController(IVegetableRepository vegetable, IMapper mapper)
        {
            _vegetable = vegetable;
            _mapper = mapper;
        }

        //Get all Vegetable
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var getVegetables = await _vegetable.GetAsync();
                if (!getVegetables.Any()) return NotFound("Vegies Empty");
                var vegetableDTOs = _mapper.Map<List<VegetableDTO>>(getVegetables);
                return Ok(vegetableDTOs.Where(image => image.IsDeleted == false));
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
                var getVegetable = await _vegetable.GetByIdAsync(id);
                if (getVegetable == null || getVegetable.IsDeleted == true) return NotFound("Vegie not found :(");
                var vegetableDTOs = _mapper.Map<VegetableDTO>(getVegetable);
                return Ok(vegetableDTOs);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        ////Post Vegetable
        [HttpPost]
        public async Task<IActionResult> Post(VegetableDTO info)
        {
            try
            {
                var createVegetable = _mapper.Map<Vegetable>(info);
                var vegetable = await _vegetable.PostAsync(createVegetable);
                var returnImage = _mapper.Map<VegetableDTO>(vegetable);
                return Ok(returnImage);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }

        }

        ////Update Vegetable
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, VegetableModel info)
        //{
        //    try
        //    {
        //        using (var context = new ECommerceDbContext())
        //        {
        //            var vegetable = context.Vegetables.Find(id);
        //            var checkCategory = context.Categories.Find(info.CategoryId);
        //            if (vegetable == null || vegetable.IsDeleted == true) return NotFound("Vegetable not found");
        //            if (checkCategory == null || checkCategory.IsDeleted == true) return NotFound("Category not found");
        //            vegetable.CategoryId = info.CategoryId;
        //            vegetable.Name = info.Name;
        //            vegetable.MFGDate = info.MFGDate;
        //            vegetable.EXPDate = info.EXPDate;
        //            vegetable.Price = info.Price;
        //            vegetable.Stock = info.Stock;
        //            context.Entry(vegetable).State = EntityState.Modified;
        //            context.SaveChanges();
        //            return Ok(new VegetableModel
        //            {
        //                Id = vegetable.Id,
        //                CategoryId = vegetable.CategoryId,
        //                Name = vegetable.Name,
        //                MFGDate = vegetable.MFGDate,
        //                EXPDate = vegetable.EXPDate,
        //                Price = vegetable.Price,
        //                Stock = vegetable.Stock,
        //                IsDeleted = vegetable.IsDeleted
        //            });
        //        }
        //    }
        //    catch
        //    {
        //        return BadRequest("Something went wrong");
        //    }
        //}

        //public class VegetableModel
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //    public int CategoryId { get; set; }
        //    public DateTime MFGDate { get; set; }
        //    public DateTime EXPDate { get; set; }
        //    public decimal Price { get; set; }
        //    public int Stock { get; set; }
        //    public bool IsDeleted { get; set; }
        //    public List<ImageModel> Images { get; set; } = new List<ImageModel>();
        //}

    }
}
