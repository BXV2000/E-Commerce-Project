using ECommerce.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace ECommerce.Customer.Controllers
{
    public class ImageController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7024/api");
        HttpClient httpClient;
        ImageReadDTO viewImage = new ImageReadDTO();
        List<ImageReadDTO> viewImages = new List<ImageReadDTO>();
        ImageCreateUpdateDTO changeImage = new ImageCreateUpdateDTO();
        List<ImageCreateUpdateDTO> changeImages = new List<ImageCreateUpdateDTO>();


        public ImageController()
        {
            httpClient = new HttpClient();
        }

        // Get all Images
        public async Task<IActionResult> Index()
        {
            using (httpClient)
            {
                using (var res = await httpClient.GetAsync(baseAddress + "/Image"))
                {
                    string apiRes = await res.Content.ReadAsStringAsync();
#pragma warning disable CS8601
                    viewImages = JsonConvert.DeserializeObject<List<ImageReadDTO>>(apiRes);
#pragma warning restore CS8601
                }
            };
            return View(viewImages);
        }

        public ViewResult Create() => View();

        // Create new Image
        [HttpPost]
        public async Task<IActionResult> Create(ImageCreateUpdateDTO info)
        {
            try
            {
                using (httpClient)
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(info), Encoding.UTF8, "application/json");
                    using (var res = await httpClient.PostAsync(baseAddress + "/Image", content))
                    {
                        string apiRes = await res.Content.ReadAsStringAsync();
#pragma warning disable CS8601
                        viewImage = JsonConvert.DeserializeObject<ImageReadDTO>(apiRes);
#pragma warning restore CS8601
                        if (res.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                        return RedirectToAction("Error");
                    }

                }
                return View();
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }


        // Edit exist Image
        public async Task<IActionResult> Edit(int id)
        {
            ImageCreateUpdateDTO viewImage = new ImageCreateUpdateDTO();
            using (httpClient)
            {

                using (var res = await httpClient.GetAsync(baseAddress + "/Image/" + id))
                {
                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await res.Content.ReadAsStringAsync();
#pragma warning disable CS8601
                        viewImage = JsonConvert.DeserializeObject<ImageCreateUpdateDTO>(apiResponse);
#pragma warning restore CS8601
                    }
                    else ViewBag.StatusCode = res.StatusCode;
                }
            }
            return View(viewImage);
        }

        [HttpPost ]
        public async Task<IActionResult> Edit(int id, ImageCreateUpdateDTO info)
        {
            using (httpClient)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(info), Encoding.UTF8, "application/json");
                using (var res = await httpClient.PutAsync(baseAddress + "/Image/" + id, content))
                {
                    string apiRes = await res.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
#pragma warning disable CS8601
                    changeImage = JsonConvert.DeserializeObject<ImageCreateUpdateDTO>(apiRes);
#pragma warning restore CS8601
                }
            }
            return View(changeImage);
        }

        public ViewResult Error() => View();


    }

   
}
