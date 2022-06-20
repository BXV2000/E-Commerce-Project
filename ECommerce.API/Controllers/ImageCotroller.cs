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
                var imageDTOs = _mapper.Map<List<ImageDTO>>(getImage);

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
                return Ok(new ImageModel
                {
                    Id = getImage.Id,
                    VegetableId = getImage.VegetableId,
                    ImageURL = getImage.ImageURL,
                });
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        //Post Image
        [HttpPost]
        public IActionResult Post(ImageModel info)
        {
            try
            {
                var checkVegetable = _context.Vegetables.Find(info.VegetableId);
                var image = new Image
                {
                    Id = info.Id,
                    VegetableId = info.VegetableId,
                    ImageURL = info.ImageURL,
                };
                if (image.VegetableId == 0) return BadRequest("Please input vegetable ID");
                if (checkVegetable == null || checkVegetable.IsDeleted == true) return NotFound("Vegetable not found");
                _context.Images.Add(image);
                _context.SaveChanges();
                return Ok(new ImageModel
                {
                    Id = image.Id,
                    VegetableId = image.VegetableId,
                    ImageURL = image.ImageURL,
                });
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        // Update Image
        [HttpPut("{id}")]
        public IActionResult Put(int id, ImageModel info)
        {
            try
            {
                using (var context = new ECommerceDbContext())
                {
                    var image = context.Images.Find(id);
                    if (image == null || image.IsDeleted == true) return NotFound("Image not found");
                    image.ImageURL = info.ImageURL;
                    context.Entry(image).State = EntityState.Modified;
                    context.SaveChanges();
                    return Ok(new ImageModel
                    {
                        Id = image.Id,
                        VegetableId = image.VegetableId,
                        ImageURL = image.ImageURL,
                    });
                }
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
                using (var context = new ECommerceDbContext())
                {
                    var image = context.Images.Find(id);
                    if (image == null || image.IsDeleted == true) return NotFound("Image not found");
                    image.IsDeleted = true;
                    context.Entry(image).State = EntityState.Modified;
                    context.SaveChanges();
                    return Ok($"Image with id = {id} was deleted ");
                }
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
