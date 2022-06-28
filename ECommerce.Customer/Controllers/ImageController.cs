using AutoMapper;
using ECommerce.API.DTOs;
using ECommerce.Customer.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Refit;
using System.Diagnostics;
using System.Text;

namespace ECommerce.Customer.Controllers
{
    public class ImageController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7024/api");
        HttpClient httpClient;
        ImageDTO viewImage = new ImageDTO();
        List<ImageDTO> viewImages = new List<ImageDTO>();
        ImageCreateUpdateDTO changeImage = new ImageCreateUpdateDTO();
        List<ImageCreateUpdateDTO> changeImages = new List<ImageCreateUpdateDTO>();
        IImageService imageService =RestService.For<IImageService>("https://localhost:7024/api");
        private readonly IMapper _mapper;


        public ImageController(IMapper mapper)
        {
            httpClient = new HttpClient();
            _mapper = mapper;
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
        public async Task<IActionResult> Create(ImageCreateUpdateDTO info)
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
                changeImage.ImageURL=viewImage.ImageURL;
                changeImage.VegetableId=viewImage.VegetableId;
                return View(changeImage);
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        // Edit exist Image
        [HttpPost ]
        public async Task<IActionResult> Edit(int id, ImageCreateUpdateDTO info)
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
