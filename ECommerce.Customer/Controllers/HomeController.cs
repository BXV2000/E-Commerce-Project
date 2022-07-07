using ECommerce.API.DTOs;
using ECommerce.API.Services;
using ECommerce.Customer.Models;
using ECommerce.Customer.Services;
using ECommerce.SharedDataModels;
using ECommerce.SharedDataModels.Authenticate;
using Microsoft.AspNetCore.Authorization;
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
        private IUserService _userService;


        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Login() => View();

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(AuthenticateRequestDTO authenticateRequest)
        {
            try
            {
                var response = _userService.Authenticate(authenticateRequest);
                if (response == null) return RedirectToAction("Error");
                HttpContext.Session.SetString("Token", response.Token);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Error");
            }
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