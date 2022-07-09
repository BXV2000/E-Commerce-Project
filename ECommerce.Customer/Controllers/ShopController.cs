using ECommerce.Customer.Services;
using ECommerce.SharedDataModels;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace ECommerce.Customer.Controllers
{
    public class ShopController : Controller
    {
        VegetableDTO viewVegetable = new VegetableDTO();
        List<VegetableDTO> viewVegetables = new List<VegetableDTO>();
        IVegetableService vegetableService = RestService.For<IVegetableService>("https://localhost:7024/api");
        private readonly ILogger<HomeController> _logger;

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
    }
}
