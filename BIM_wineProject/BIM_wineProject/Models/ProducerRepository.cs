using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;

namespace BIM_wineProject.Models
{
    public class ProducerRepository : IProducer
    {

        private readonly masterEntities dbo = new masterEntities();
        public async Task Add(Producer producer)
        {
            producer.ProducerID = Guid.NewGuid().ToString();
            dbo.Producers.Add(producer);
            try
            {
                await dbo.SaveChanges();
            }
            catch
            {
                throw;
            }

        }

        public async Task<Producer> GetProducer(int id)  
        {  
            try  
            {  
                Producer producer = await dbo.Producers.FindAsync(id);  
                if (producer == null)  
                {  
                    return null;  
                }  
                return producer;  
            }  
            catch  
            {  
                throw;  
            }  
        }  
        public async Task<IEnumerable<Producer>> GetProducers()  
        {  
            try  
            {  
                var producers = await dbo.Producers.ToListAsync();  
                return producers.AsQueryable();  
            }  
            catch  
            {  
                throw;  
            }  
        }  
        public async Task Update(Producer producer)  
        {  
            try  
            {  
                dbo.Entry(producer).State = EntityState.Modified;  
                await dbo.SaveChangesAsync();  
            }  
            catch  
            {  
                throw;  
            }  
        }  
        public async Task Delete(int id)  
        {  
            try  
            {  
                Producer producer = await dbo.Producers.FindAsync(id);  
                dbo.Producers.Remove(producer);  
                await dbo.SaveChangesAsync();  
            }  
            catch  
            {  
                throw;  
            }  
        }  
  
        private bool ProducerExists(int id)  
        {  
            return dbo.Producers.Count(e => e.ProducerID == id) > 0;  
        }  
  
    }  

}
