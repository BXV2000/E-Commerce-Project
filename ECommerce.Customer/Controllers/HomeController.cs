using ECommerce.API.DTOs;
using ECommerce.Customer.Models;
using ECommerce.Customer.Services;
using ECommerce.SharedDataModels;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Diagnostics;

namespace ECommerce.Customer.Controllers
{
    public class HomeController : Controller
    {
        VegetableDTO viewVegetable = new VegetableDTO();
        List<VegetableDTO> viewVegetables = new List<VegetableDTO>();
        IVegetableService vegetableService = RestService.For<IVegetableService>("https://localhost:7024/api");
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

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

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Image()
        {
            return View();
        }

        //public IActionResult Vegetable()    
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}