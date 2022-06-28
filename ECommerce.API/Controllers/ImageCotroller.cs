using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerce.API.Models;
using ECommerce.API.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ECommerce.API.DTOs;
using ECommerce.API.Interfaces;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IImageRepository _image;
        public ImageController(IImageRepository image, IMapper mapper )
        {
            _mapper = mapper;
            _image = image;
        }

        //Get all Image
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var getImages = await _image.GetAsync();
                var imageDTOs = _mapper.Map<List<ImageDTO>>(getImages);
                
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
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var getImage = await _image.GetByIdAsync(id);
                if (getImage == null || getImage.IsDeleted == true) return NotFound("Image not found :(");
                var imageDTOs = _mapper.Map<ImageDTO>(getImage);
                return Ok(imageDTOs);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        //Create Image
        [HttpPost]
        public async Task<IActionResult> Post(ImageDTO info)
        {
            try
            {
                //var checkVegetable = _context.Vegetables.Find(info.VegetableId);
                var createImage = _mapper.Map<Image>(info);
                //if (createImage.VegetableId == 0) return BadRequest("Please input vegetable ID");
                //if (checkVegetable == null || checkVegetable.IsDeleted == true) return NotFound("Vegetable not found");
                var image = await _image.PostAsync(createImage);
                var returnImage = _mapper.Map<ImageDTO>(image);
                return Ok(returnImage);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        // Update Image
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ImageDTO info)
        {
            try
            {
                var image = _mapper.Map<Image>(info);
                var putImage = await _image.PutAsync(id, image);
                //var checkVegetable = _context.Vegetables.Find(info.VegetableId);
                //if (checkVegetable == null || checkVegetable.IsDeleted == true) return NotFound("Vegetable not found");
                var returnImage = _mapper.Map<ImageDTO>(putImage);
                return Ok(returnImage);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        // Delete Image
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var checkImage = await _image.GetByIdAsync(id);
                if (checkImage == null || checkImage.IsDeleted == true) return NotFound("Image not found");
                await _image.DeleteAsync(id);
                return Ok("Image Deleted");
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
