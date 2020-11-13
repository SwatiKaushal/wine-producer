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
    public class BottleController : Controller
    {
        //
        // GET: /Bottle/

        readonly string apiBaseAddress = ConfigurationManager.AppSettings["apiBaseAddress"];  
        public async Task<ActionResult> Index()
        {  
            IEnumerable <Bottle> bottles = null;  
  
            using (var client = new HttpClient())  
            {  
                client.BaseAddress = new Uri(apiBaseAddress);  
  
                var result = await client.GetAsync("bottles/get");  
  
                if (result.IsSuccessStatusCode)  
                {  
                    bottles = await result.Content.ReadAsAsync<IList<Bottle>>();  
                }  
                else  
                {  
                    bottles = Enumerable.Empty<Bottle>();  
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");  
                }  
            }  
            return View(bottles);  
        }  
  
        public async Task<ActionResult> Details_bottles(int id)  
        {  
            if (id == null)  
            {  
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);  
            }  
  
            Bottle bottles = null;  
            using (var client = new HttpClient())  
            {  
                client.BaseAddress = new Uri(apiBaseAddress);  
  
                var result = await client.GetAsync("Bottle/details/{id}");  
  
                if (result.IsSuccessStatusCode)  
                {  
                    bottles = await result.Content.ReadAsAsync<Bottle>();  
                }  
                else  
                {  
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");  
                }  
            }  
  
            if (bottles == null)  
            {  
                return HttpNotFound();  
            }  
            return View(bottles);  
        }  
  
        public ActionResult Create()  
        {  
            return View();  
        }  
  
        [HttpPost]  
        [ValidateAntiForgeryToken]  
        public async Task<ActionResult> Create_bottles([Bind(Include = "Name,Year,Size,styles,taste,C_Description,Food_Pairing,C_image,link")] Bottle bottles)  
        {  
            if (ModelState.IsValid)  
            {  
                using (var client = new HttpClient())  
                {  
                    client.BaseAddress = new Uri(apiBaseAddress);  
  
                    var response = await client.PostAsJsonAsync("bottles/Create", bottles);  
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
            return View(bottles);  
        }  
  
        public async Task<ActionResult> Edit_bottles(int id)  
        {  
            if (id == null)  
            {  
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);  
            }  
            Bottle bottles = null;  
            using (var client = new HttpClient())  
            {  
                client.BaseAddress = new Uri(apiBaseAddress);  
  
                var result = await client.GetAsync("bottles/details/{id}");  
  
                if (result.IsSuccessStatusCode)  
                {  
                    bottles = await result.Content.ReadAsAsync<Bottle>();  
                }  
                else  
                {  
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");  
                }  
            }  
            if (bottles == null)  
            {  
                return HttpNotFound();  
            }  
            return View(bottles);  
        }  
  
        [HttpPost]  
        [ValidateAntiForgeryToken]  
        public async Task<ActionResult> Edit_bottles([Bind(Include = "BottleID,Name,Year,Size,styles,taste,C_Description,Food_Pairing,C_image,link")] Bottle bottles)  
        {  
            if (ModelState.IsValid)  
            {  
                using (var client = new HttpClient())  
                {  
                    client.BaseAddress = new Uri(apiBaseAddress);  
                    var response = await client.PutAsJsonAsync("bottles/edit", bottles);  
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
            return View(bottles);  
        }  
  
        public async Task<ActionResult> Delete(int id)  
        {  
            if (id == null)  
            {  
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);  
            }  
            Bottle bottles = null;  
            using (var client = new HttpClient())  
            {  
                client.BaseAddress = new Uri(apiBaseAddress);  
  
                var result = await client.GetAsync("bottles/details/{id}");  
  
                if (result.IsSuccessStatusCode)  
                {  
                    bottles = await result.Content.ReadAsAsync<Bottle>();  
                }  
                else  
                {  
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");  
                }  
            }  
  
            if (bottles == null)  
            {  
                return HttpNotFound();  
            }  
            return View(bottles);  
        }  
  
        [HttpPost, ActionName("Delete")]  
        [ValidateAntiForgeryToken]  
        public async Task<ActionResult> DeleteConfirmed(int id)  
        {  
            using (var client = new HttpClient())  
            {  
                client.BaseAddress = new Uri(apiBaseAddress);  
  
                var response = await client.DeleteAsync("bottles/delete/{id}");  
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
