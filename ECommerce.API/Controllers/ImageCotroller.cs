using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerce.API.Models;
using ECommerce.API.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ECommerceDbContext _context;

        public ImageController(ECommerceDbContext context)
        {
            _context = context;
        }

        //Get all Image
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var getImage = _context.Images.Select(image => new ImageModel
                {
                    Id = image.Id,
                    VegetableId = image.VegetableId,
                    ImageURL = image.ImageURL,
                }).ToList();
                if (!getImage.Any()) return NotFound("Image Empty");
                return Ok(getImage.Where(image => image.IsDeleted == false));
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

        public class ImageModel
        {
            public int Id { get; set; }
            public int VegetableId { get; set; }
            public string ImageURL { get; set; }
            public bool IsDeleted { get; set; }
        }

    }
}
