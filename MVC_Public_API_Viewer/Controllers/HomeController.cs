using Microsoft.AspNetCore.Mvc;
using MVC_Public_API_Viewer.Models;
using Newtonsoft.Json;
using System.Collections;
using System.Diagnostics;
using System.Text.Json;

namespace MVC_Public_API_Viewer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string catFilter)
        {
            //string result;
            DataViewModel.Rootobject result;
            if (catFilter != null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://api.publicapis.org/entries?category=" + catFilter);

                    HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
                    response.EnsureSuccessStatusCode();
                    var JSONData = JsonConvert.DeserializeObject<DataViewModel.Rootobject>(response.Content.ReadAsStringAsync().Result);
                    result = JSONData;
                }
            }
            else
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://api.publicapis.org/entries");
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
                    response.EnsureSuccessStatusCode();
                    var JSONData = JsonConvert.DeserializeObject<DataViewModel.Rootobject>(response.Content.ReadAsStringAsync().Result);
                    result = JSONData;
                }
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.publicapis.org/categories");
                HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
                response.EnsureSuccessStatusCode();
                var JSONData = JsonConvert.DeserializeObject<DataViewModel.Rootobject>(response.Content.ReadAsStringAsync().Result);
                result.categories = JSONData.categories;
            }

            result.selectedCategory = catFilter;

            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Data(string catFilter)
        {
            //string result;
            DataViewModel.Rootobject result;
            if(catFilter != null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://api.publicapis.org/entries?category=" + catFilter);
                    
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
                    response.EnsureSuccessStatusCode();
                    var JSONData = JsonConvert.DeserializeObject<DataViewModel.Rootobject>(response.Content.ReadAsStringAsync().Result);
                    result = JSONData;
                }
            } else
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://api.publicapis.org/entries");
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
                    response.EnsureSuccessStatusCode();
                    var JSONData = JsonConvert.DeserializeObject<DataViewModel.Rootobject>(response.Content.ReadAsStringAsync().Result);
                    result = JSONData;
                }
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.publicapis.org/categories");
                HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
                response.EnsureSuccessStatusCode();
                var JSONData = JsonConvert.DeserializeObject<DataViewModel.Rootobject>(response.Content.ReadAsStringAsync().Result);
                result.categories = JSONData.categories;
            }

            result.selectedCategory = catFilter;

            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}