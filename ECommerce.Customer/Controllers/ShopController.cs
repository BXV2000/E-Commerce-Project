using ECommerce.Customer.Models;
using ECommerce.Customer.Services;
using ECommerce.SharedDataModels;
using ECommerce.SharedDataModels.Enums;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Dynamic;

namespace ECommerce.Customer.Controllers
{
    public class ShopController : Controller
    {
        VegetableDTO viewVegetable = new VegetableDTO();
        RatingDTO rating = new RatingDTO();
        List<VegetableDTO> viewVegetables = new List<VegetableDTO>();
        List<CategoryDTO> viewCategories = new List<CategoryDTO>();
        IVegetableService vegetableService = RestService.For<IVegetableService>("https://localhost:7024/api");
        ICategoryService categoryService = RestService.For<ICategoryService>("https://localhost:7024/api");
        IRatingService ratingService = RestService.For<IRatingService>("https://localhost:7024/api");
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
                MultiModels customModel = new MultiModels();
                customModel.Vegetable = await vegetableService.GetVegetable(id);
                customModel.Vegetables = await vegetableService.GetVegetables();
                var ratings = await ratingService.GetRatingsByProductId(id);
                if (ratings.Count() > 0)
                {
                    var ratingSum = ratings.Sum(d => d.RatingNumber);
                    ViewBag.RatingSum = ratingSum;
                    var ratingCount = ratings.Count();
                    ViewBag.RatingCount = ratingCount;
                }
                else
                {
                    ViewBag.RatingSum = 0;
                    ViewBag.RatingCount = 0;
                }
                return View(customModel);
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

        [ECommerce.API.Authorization.Authorize(UserRole.Customer)]
        public async Task<IActionResult> Rating(int id)
        {
            try
            {
                MultiModels customModel = new MultiModels();
                customModel.Vegetable = await vegetableService.GetVegetable(id);
                customModel.Ratings = await ratingService.GetRatingsByProductId(id);
                var ratings = await ratingService.GetRatingsByProductId(id);
                if (ratings.Count() > 0)
                {
                    var ratingSum = ratings.Sum(d => d.RatingNumber);
                    ViewBag.RatingSum = ratingSum;
                    var ratingCount = ratings.Count();
                    ViewBag.RatingCount = ratingCount;
                }
                else
                {
                    ViewBag.RatingSum = 0;
                    ViewBag.RatingCount = 0;
                }
                return View(customModel);
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Rating(int RatingNumber, int ProductId)
        {
            try
            {
                rating.VegetableId = ProductId;
                rating.RatingNumber = RatingNumber;
                await ratingService.CreateRating(rating);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }
    }
}
