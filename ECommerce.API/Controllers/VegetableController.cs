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
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, VegetableDTO info)
        {
            try
            {
                var vege = _mapper.Map<Vegetable>(info);
                var putVegetable = await _vegetable.PutAsync(id, vege);
                //var checkVegetable = _context.Vegetables.Find(info.VegetableId);
                //if (checkVegetable == null || checkVegetable.IsDeleted == true) return NotFound("Vegetable not found");
                var returnVegetable = _mapper.Map<VegetableDTO>(putVegetable);
                return Ok(returnVegetable);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var checkVegetable = await _vegetable.GetByIdAsync(id);
                if (checkVegetable == null || checkVegetable.IsDeleted == true) return NotFound("Image not found");
                await _vegetable.DeleteAsync(id);
                return Ok("Image Deleted");
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

    }
}
