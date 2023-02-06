using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Public_API_Viewer.Models;
using Newtonsoft.Json;

namespace MVC_Public_API_Viewer.Controllers
{
    public class RequestController : Controller
    {
        // GET: HomeController1
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string Name, string Link, string newLink, string Params)
        {
            RequestViewModel model = new RequestViewModel();
            model.Name= Name;
            if (newLink != null)
            {
                model.Link= newLink;
            }
            else
            {
                model.Link= Link;
            }

            if(Params != null)
            {
                model.Params= Params;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(model.Link + model.Params);

                    HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
                    response.EnsureSuccessStatusCode();
                    model.Response = response.Content.ReadAsStringAsync().Result;
                }
            }
            return View(model);
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
