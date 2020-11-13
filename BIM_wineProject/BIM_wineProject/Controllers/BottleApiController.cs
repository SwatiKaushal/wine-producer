using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
//using AttributeRouting.Web.Http;
using BIM_wineProject.Models;

namespace BIM_wineProject.Controllers
{
    public class BottleApiController : Controller
    {
        private readonly IBottle _iBottle = new BottleRepository();

        [HttpGet]
        [Route("api/Bottles/Get")]
        public async Task <IEnumerable<Bottle>> Get()
        {
            return await _iBottle.GetBottles();
        }

        [HttpPost]
        [Route("api/Bottles/Create")]
        public async Task CreateAsync([FromBody]Bottle bottles)
        {
            if (ModelState.IsValid)
            {
                await _iBottle.Add(bottles);
            }
        }

        [HttpGet]
        [Route("api/Bottles/Details/{id}")]
        public async Task<Bottle> Details(int id)
        {
            var result = await _iBottle.GetBottle(id);
            return result;
        }

        [HttpPut]
        [Route("api/Bottles/Edit")]
        public async Task EditAsync([FromBody]Bottle bottles)
        {
            if (ModelState.IsValid)
            {
                await _iBottle.Update(bottles);
            }
        }

        [HttpDelete]
        [Route("api/Bottles/Delete/{id}")]
        public async Task DeleteConfirmedAsync(int id)
        {
            await _iBottle.Delete(id);
        }  
    }
}
