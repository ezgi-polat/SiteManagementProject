using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiteManagementProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementProject.Controllers
{
  
    [Authorize(Roles="Admin,Menu")]
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            var responseMessage = client.GetAsync("http://localhost:64525/api/menus/").Result;
            List<Menu> menus = null;
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                menus = JsonConvert.DeserializeObject<List<Menu>>(responseMessage.Content.ReadAsStringAsync().Result);
            }
            return View(menus);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View(new Menu());
        }
        [HttpPost]
        public IActionResult Add(Menu menu)
        {
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(menu), Encoding.UTF8, "application/json");
            var responseMessage = httpClient.PostAsync("http://localhost:64525/api/menus/", content).Result;
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.Created)
            {
                //products = JsonConvert.DeserializeObject<List<Product>>(responseMessage.Content.ReadAsStringAsync().Result);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Ekleme işlemi başarısız!");
            return View();

        }
        public IActionResult Edit(int id)
        {
            HttpClient httpClient = new HttpClient();
            var responseMessage = httpClient.GetAsync("http://localhost:64525/api/menus/" + id).Result;
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var menu = JsonConvert.DeserializeObject<Menu>(responseMessage.Content.ReadAsStringAsync().Result);
                return View(menu);
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Menu menu)
        {
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(menu), Encoding.UTF8, "application/json");

            var responseMessage = httpClient.PutAsync("http://localhost:64525/api/menus/" + menu.MenuId, content).Result;
            //if (responseMessage.StatusCode == System.Net.HttpStatusCode.NoContent)
            //{
            //    var product = JsonConvert.DeserializeObject<Product>(responseMessage.Content.ReadAsStringAsync().Result);
            //    return View(product);
            //}

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            HttpClient httpClient = new HttpClient();
            var responseMessage = httpClient.DeleteAsync("http://localhost:64525/api/menus/" + id).Result;


            return RedirectToAction("Index");
        }
    }
}
