using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Customer.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
