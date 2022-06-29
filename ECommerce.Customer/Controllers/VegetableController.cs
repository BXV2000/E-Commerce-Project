using AutoMapper;
using ECommerce.SharedDataModels;
using ECommerce.Customer.Services;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace ECommerce.Customer.Controllers
{
    public class VegetableController : Controller
    {
        VegetableDTO viewVegetale = new VegetableDTO();
        List<VegetableDTO> viewVegetables = new List<VegetableDTO>();
        IVegetableService vegetableService =RestService.For<IVegetableService>("https://localhost:7024/api");


        public VegetableController(IMapper mapper)
        {
        }

        // Get all Images
        public async Task<IActionResult> Index()
        {
            try
            {
                viewVegetables = await vegetableService.GetVegetables();
                return View(viewVegetables);
            }
            catch 
            {
                return RedirectToAction("Error");
            }
        }

        //public ViewResult Create() => View();

        //// Create new Image
        //[HttpPost]
        //public async Task<IActionResult> Create(ImageDTO info)
        //{
        //    try
        //    {
        //        await imageService.CreateImage(info);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return RedirectToAction("Error");
        //    }
        //}


        //// Get an Image by ID
        //public async  Task<IActionResult> Edit(int id)
        //{
        //    try
        //    { 
        //        viewImage =await imageService.GetImage(id);        
        //        return View(viewImage);
        //    }
        //    catch
        //    {
        //        return RedirectToAction("Error");
        //    }
        //}

        //// Edit exist Image
        //[HttpPost ]
        //public async Task<IActionResult> Edit(int id, ImageDTO info)
        //{
        //    try
        //    {
        //        await imageService.UpdateImage(id, info);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return RedirectToAction("Error");
        //    }
        //}

        //// Delete an Image
        ////[HttpPost]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        await imageService.DeleteImage(id);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return RedirectToAction("Error");
        //    }
        //}

        //public ViewResult Error() => View();
    }

   
}
