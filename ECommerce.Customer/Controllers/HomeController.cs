
using ECommerce.API.Interfaces;
using ECommerce.API.Services;
using ECommerce.Customer.Models;
using ECommerce.Customer.Services;
using ECommerce.SharedDataModels;
using ECommerce.SharedDataModels.Authenticate;
using ECommerce.SharedDataModels.Enums;
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
        private IAuthenticateService _userService;


        public HomeController(IAuthenticateService userService)
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

        public IActionResult Image()
        {
            return View();
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

        [ECommerce.API.Authorization.Authorize(UserRole.Customer)]
        [Route("index")]
        [HttpGet]


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
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