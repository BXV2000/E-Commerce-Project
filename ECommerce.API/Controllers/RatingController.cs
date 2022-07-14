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
    public class RatingController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRatingRepository _rating;

        public RatingController(IRatingRepository rating, IMapper mapper)
        {
            _rating = rating;
            _mapper = mapper;
        }

        // Get all Ratings
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var getRatings = await _rating.GetAsync();
                if (!getRatings.Any()) return NotFound("Rating Empty");
                var ratingDTOs = _mapper.Map<List<RatingDTO>>(getRatings);
                return Ok(ratingDTOs);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }


        }

        ////Get one Rating
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var getRating = await _rating.GetByIdAsync(id);
                if (getRating == null || getRating.IsDeleted == true) return NotFound("Rating not found :(");
                var ratingDTO = _mapper.Map<RatingDTO>(getRating);
                return Ok(ratingDTO);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        ////Get Ratings by ProductId
        [HttpGet("vegetable/{id}")]
        public async Task<IActionResult> GetByProductId(int id)
        {
            try
            {
                var getRatings = await _rating.GetByVegetableIdAsync(id);
                if (!getRatings.Any()) return NotFound("Ratings not found :(");
                var ratingDTO = _mapper.Map<List<RatingDTO>>(getRatings);
                return Ok(ratingDTO);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        ////Post Category
        [HttpPost]
        public async Task<IActionResult> Post(RatingDTO info)
        {
            try
            {
                var createRating = _mapper.Map<Rating>(info);
                var rating = await _rating.PostAsync(createRating);
                var returnRating = _mapper.Map<RatingDTO>(rating);
                return Ok(returnRating);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }

        }

        ////Put Category
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, RatingDTO info)
        {
            try
            {
                var rating = _mapper.Map<Rating>(info);
                var putRating = await _rating.PutAsync(id, rating);
                //var checkVegetable = _context.Vegetables.Find(info.VegetableId);
                //if (checkVegetable == null || checkVegetable.IsDeleted == true) return NotFound("Vegetable not found");
                var returnRating = _mapper.Map<RatingDTO>(putRating);
                return Ok(returnRating);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        ////Delete Category
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var checkRating = await _rating.GetByIdAsync(id);
                if (checkRating == null || checkRating.IsDeleted == true) return NotFound("Rating not found");
                await _rating.DeleteAsync(id);
                return Ok("Rating Deleted");
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }


    }
}
