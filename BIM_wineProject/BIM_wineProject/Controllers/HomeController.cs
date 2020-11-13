using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using BIM_wineProject.Models;

namespace BIM_wineProject.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    return View();
        //}

        readonly string apiBaseAddress = ConfigurationManager.AppSettings["apiBaseAddress"];  
        public async Task<ActionResult> Index()  
        {  
            IEnumerable<Producer> producers = null;  
  
            using (var client = new HttpClient())  
            {  
                client.BaseAddress = new Uri(apiBaseAddress);  
  
                var result = await client.GetAsync("producers/get");  
  
                if (result.IsSuccessStatusCode)  
                {  
                    producers = await result.Content.ReadAsAsync<IList<Producer>>();  
                }  
                else  
                {  
                    producers = Enumerable.Empty<Producer>();  
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");  
                }  
            }  
            return View(producers);  
        }  
  
        public async Task<ActionResult> Details(int id)  
        {  
            if (id == null)  
            {  
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);  
            }  
  
            Producer producers = null;  
            using (var client = new HttpClient())  
            {  
                client.BaseAddress = new Uri(apiBaseAddress);  
  
                var result = await client.GetAsync("Producer/details/{id}");  
  
                if (result.IsSuccessStatusCode)  
                {  
                    producers = await result.Content.ReadAsAsync<Producer>();  
                }  
                else  
                {  
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");  
                }  
            }  
  
            if (producers == null)  
            {  
                return HttpNotFound();  
            }  
            return View(producers);  
        }  
  
        public ActionResult Create()  
        {  
            return View();  
        }  
  
        [HttpPost]  
        [ValidateAntiForgeryToken]  
        public async Task<ActionResult> Create([Bind(Include = "Name,Address,BottleID")] Producer producers)  
        {  
            if (ModelState.IsValid)  
            {  
                using (var client = new HttpClient())  
                {  
                    client.BaseAddress = new Uri(apiBaseAddress);  
  
                    var response = await client.PostAsJsonAsync("producers/Create", producers);  
                    if (response.IsSuccessStatusCode)  
                    {  
                        return RedirectToAction("Index");  
                    }  
                    else  
                    {  
                        ModelState.AddModelError(string.Empty, "Server error try after some time.");  
                    }  
                }  
            }  
            return View(producers);  
        }  
  
        public async Task<ActionResult> Edit(int id)  
        {  
            if (id == null)  
            {  
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);  
            }  
            Producer producers = null;  
            using (var client = new HttpClient())  
            {  
                client.BaseAddress = new Uri(apiBaseAddress);  
  
                var result = await client.GetAsync("producers/details/{id}");  
  
                if (result.IsSuccessStatusCode)  
                {  
                    producers = await result.Content.ReadAsAsync<Producer>();  
                }  
                else  
                {  
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");  
                }  
            }  
            if (producers == null)  
            {  
                return HttpNotFound();  
            }  
            return View(producers);  
        }  
  
        [HttpPost]  
        [ValidateAntiForgeryToken]  
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Address,BottleID")] Producer producers)  
        {  
            if (ModelState.IsValid)  
            {  
                using (var client = new HttpClient())  
                {  
                    client.BaseAddress = new Uri(apiBaseAddress);  
                    var response = await client.PutAsJsonAsync("producers/edit", producers);  
                    if (response.IsSuccessStatusCode)  
                    {  
                        return RedirectToAction("Index");  
                    }  
                    else  
                    {  
                        ModelState.AddModelError(string.Empty, "Server error try after some time.");  
                    }  
                }  
                return RedirectToAction("Index");  
            }  
            return View(producers);  
        }  
  
        public async Task<ActionResult> Delete(int id)  
        {  
            if (id == null)  
            {  
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);  
            }  
            Producer producers = null;  
            using (var client = new HttpClient())  
            {  
                client.BaseAddress = new Uri(apiBaseAddress);  
  
                var result = await client.GetAsync("producers/details/{id}");  
  
                if (result.IsSuccessStatusCode)  
                {  
                    producers = await result.Content.ReadAsAsync<Producer>();  
                }  
                else  
                {  
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");  
                }  
            }  
  
            if (producers == null)  
            {  
                return HttpNotFound();  
            }  
            return View(producers);  
        }  
  
        [HttpPost, ActionName("Delete")]  
        [ValidateAntiForgeryToken]  
        public async Task<ActionResult> DeleteConfirmed(int id)  
        {  
            using (var client = new HttpClient())  
            {  
                client.BaseAddress = new Uri(apiBaseAddress);  
  
                var response = await client.DeleteAsync("producers/delete/{id}");  
                if (response.IsSuccessStatusCode)  
                {  
                    return RedirectToAction("Index");  
                }  
                else  
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");  
            }  
            return View();  
        } 
    }
}
