using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
//using System.Web.Http;
using BIM_wineProject.Models;

namespace BIM_wineProject.Controllers
{
    public class ProducerApiController : Controller
    {
        private readonly IProducer _iProducer = new ProducerRepository();

        [HttpGet]
        [Route("api/Producers/Get")]
        public async Task<IEnumerable<Producer>> Get()
        {
            return await _iProducer.GetProducers();
        }

        [HttpPost]
        [Route("api/Producers/Create")]
        public async Task CreateAsync([FromBody]Producer producers)
        {
            if (ModelState.IsValid)
            {
                await _iProducer.Add(producers);
            }
        }

        [HttpGet]
        [Route("api/Producers/Details/{id}")]
        public async Task<Producer> Details(int id)
        {
            var result = await _iProducer.GetProducer(id);
            return result;
        }

        [HttpPut]
        [Route("api/Producers/Edit")]
        public async Task EditAsync([FromBody]Producer producers)
        {
            if (ModelState.IsValid)
            {
                await _iProducer.Update(producers);
            }
        }

        [HttpDelete]
        [Route("api/Producers/Delete/{id}")]
        public async Task DeleteConfirmedAsync(int id)
        {
            await _iProducer.Delete(id);
        }  

    }
}
