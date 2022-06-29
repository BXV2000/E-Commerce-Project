using AutoMapper;
using ECommerce.API.DTOs;
using ECommerce.Customer.Services;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace ECommerce.Customer.Controllers
{
    public class ImageController : Controller
    {

        ImageDTO viewImage = new ImageDTO();
        List<ImageDTO> viewImages = new List<ImageDTO>();
        IImageService imageService =RestService.For<IImageService>("https://localhost:7024/api");


        public ImageController(IMapper mapper)
        {
        }

        // Get all Images
        public async Task<IActionResult> Index()
        {
            try
            {
                viewImages = await imageService.GetImages();
                return View(viewImages);
            }
            catch 
            {
                return RedirectToAction("Error");
            }
        }

        public ViewResult Create() => View();

        // Create new Image
        [HttpPost]
        public async Task<IActionResult> Create(ImageDTO info)
        {
            try
            {
                await imageService.CreateImage(info);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }


        // Get an Image by ID
        public async  Task<IActionResult> Edit(int id)
        {
            try
            { 
                viewImage =await imageService.GetImage(id);        
                return View(viewImage);
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        // Edit exist Image
        [HttpPost ]
        public async Task<IActionResult> Edit(int id, ImageDTO info)
        {
            try
            {
                await imageService.UpdateImage(id, info);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        // Delete an Image
        //[HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await imageService.DeleteImage(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        public ViewResult Error() => View();
    }

   
}
