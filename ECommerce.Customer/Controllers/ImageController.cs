using ECommerce.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.Customer.Controllers
{
    public class ImageController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7024/api");
        HttpClient httpClient;
        ImageReadDTO image = new ImageReadDTO();
        List<ImageReadDTO> images = new List<ImageReadDTO>();

        public ImageController()
        {
            httpClient = new HttpClient();
        }

        public async Task<IActionResult> Index()
        {
            using (httpClient)
            {
                using(var res =await httpClient.GetAsync(baseAddress + "/Image"))
                {
                    string apiRes =await res.Content.ReadAsStringAsync();
                    #pragma warning disable CS8601
                    images = JsonConvert.DeserializeObject<List<ImageReadDTO>>(apiRes);
                    #pragma warning restore CS8601
                }
            };
            return View(images);
        }
    }

   
}
