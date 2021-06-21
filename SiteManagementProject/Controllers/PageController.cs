using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiteManagementProject.Models;
using SiteManagementProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementProject.Controllers
{
    [Authorize(Roles = "Admin,Menu,Page")]
    public class PageController : Controller
    {
    
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            var responseMessage = client.GetAsync("http://localhost:64525/api/pages").Result;
            List<Pages> products = null;
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                products = JsonConvert.DeserializeObject<List<Pages>>(responseMessage.Content.ReadAsStringAsync().Result);
            }
            return View(products);
        }
        [HttpGet]
        public IActionResult Add()
        {
            PageRepository pageRepository = new PageRepository();
            var pageList = pageRepository.TList();
            ViewBag.dropDownList1 = pageList;
            return View(new Pages());
        }
        [HttpPost]
        public IActionResult Add(Pages page)
        {
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(page), Encoding.UTF8, "application/json");
            var responseMessage = httpClient.PostAsync("http://localhost:64525/api/pages/", content).Result;
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
            var responseMessage = httpClient.GetAsync("http://localhost:64525/api/pages/" + id).Result;
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var page = JsonConvert.DeserializeObject<Pages>(responseMessage.Content.ReadAsStringAsync().Result);
                return View(page);
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Pages page)
        {
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(page), Encoding.UTF8, "application/json");

            var responseMessage = httpClient.PutAsync("http://localhost:64525/api/pages/" + page.PageId, content).Result;
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
            var responseMessage = httpClient.DeleteAsync("http://localhost:64525/api/pages/" + id).Result;


            return RedirectToAction("Index");
        }
    }
}
