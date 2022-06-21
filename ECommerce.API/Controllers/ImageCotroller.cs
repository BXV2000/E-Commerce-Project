using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerce.API.Models;
using ECommerce.API.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ECommerce.API.DTOs;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ECommerceDbContext _context;
        private readonly IMapper _mapper;
        public ImageController(ECommerceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Get all Image
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var getImage = _context.Images.ToList();
                var imageDTOs = _mapper.Map<List<ImageReadDTO>>(getImage);

                if (!imageDTOs.Any()) return NotFound("Image Empty");
                return Ok(imageDTOs.Where(image => image.IsDeleted==false));
            }
            catch
            {
                return BadRequest("Something went wrong");
            }

        }

        //Get one Image
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var getImage = _context.Images.Find(id);
                if (getImage == null || getImage.IsDeleted == true) return NotFound("Image not found :(");
                var imageDTOs = _mapper.Map<ImageReadDTO>(getImage);
                return Ok(imageDTOs);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        //Create Image
        [HttpPost]
        public IActionResult Post(ImageCreateUpdateDTO info)
        {
            try
            {
                var checkVegetable = _context.Vegetables.Find(info.VegetableId);
                var createImage = _mapper.Map<Image>(info);
                if (createImage.VegetableId == 0) return BadRequest("Please input vegetable ID");
                if (checkVegetable == null || checkVegetable.IsDeleted == true) return NotFound("Vegetable not found");
                var image = _context.Images.Add(createImage);
                var returnImage = _mapper.Map<ImageReadDTO>(createImage);
                _context.SaveChanges();
                return Ok(returnImage);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        // Update Image
        [HttpPut("{id}")]
        public IActionResult Put(int id, ImageCreateUpdateDTO info)
        {
            try
            {
                var checkImage = _context.Images.Find(id);
                var checkVegetable = _context.Vegetables.Find(info.VegetableId);
                if (checkImage == null || checkImage.IsDeleted == true) return NotFound("Image not found");
                if (checkVegetable == null || checkVegetable.IsDeleted == true) return NotFound("Vegetable not found");
                checkImage.VegetableId = info.VegetableId;
                checkImage.ImageURL = info.ImageURL;
                _context.SaveChanges();
                var returnImage = _mapper.Map<ImageReadDTO>(checkImage);
                return Ok(returnImage);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        // Delete Image
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var checkImage = _context.Images.Find(id);
                if (checkImage == null || checkImage.IsDeleted == true) return NotFound("Image not found");
                checkImage.IsDeleted = true;
                _context.SaveChanges();
                var returnImage = _mapper.Map<ImageReadDTO>(checkImage);
                return Ok(returnImage);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        public class ImageModel
        {
            public int Id { get; set; }
            public int VegetableId { get; set; }
            public string ImageURL { get; set; }
            public bool IsDeleted { get; set; }
        }

    }
}
