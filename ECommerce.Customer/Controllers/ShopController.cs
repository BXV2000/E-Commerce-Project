using ECommerce.Customer.Models;
using ECommerce.Customer.Services;
using ECommerce.SharedDataModels;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Dynamic;

namespace ECommerce.Customer.Controllers
{
    public class ShopController : Controller
    {
        VegetableDTO viewVegetable = new VegetableDTO();
        List<VegetableDTO> viewVegetables = new List<VegetableDTO>();
        List<CategoryDTO> viewCategories = new List<CategoryDTO>();
        IVegetableService vegetableService = RestService.For<IVegetableService>("https://localhost:7024/api");
        ICategoryService categoryService = RestService.For<ICategoryService>("https://localhost:7024/api");
        private readonly ILogger<HomeController> _logger;

        public async Task<IActionResult> Index()
        {
            try
            {
                //viewVegetables = await vegetableService.GetVegetables();
                //viewCategories = await categoryService.GetCategories();
                MultiModels customModel = new MultiModels();
                customModel.Vegetables= await vegetableService.GetVegetables();
                customModel.Categories = await categoryService.GetCategories();
                return View(customModel);
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                viewVegetable = await vegetableService.GetVegetable(id);
                return View(viewVegetable);
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        public async Task<IActionResult> Category(int id)
        {
            try
            {
                MultiModels customModel = new MultiModels();
                customModel.Category = await categoryService.GetCategory(id);
                customModel.Categories = await categoryService.GetCategories();
                return View(customModel);
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }
    }
}
