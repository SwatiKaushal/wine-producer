using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;

namespace BIM_wineProject.Models
{
    public class BottleRepository : IBottle
    {
        private readonly masterEntities dbo = new masterEntities();
        public async Task Add(Bottle bottle)
        {
            bottle.BottleID = Guid.NewGuid().ToString();
            dbo.Bottles.Add(bottle);
            try
            {
                await dbo.SaveChanges();
            }
            catch
            {
                throw;
            }

        }

        public async Task<Bottle> GetBottle(int id)
        {
            try
            {
                Bottle bottle = await dbo.Bottles.FindAsync(id);
                if (bottle == null)
                {
                    return null;
                }
                return bottle;
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Bottle>> GetBottles()
        {
            try
            {
                var bottles = await dbo.Bottles.ToListAsync();
                return bottles.AsQueryable();
            }
            catch
            {
                throw;
            }
        }
        public async Task Update(Bottle bottle)
        {
            try
            {
                dbo.Entry(bottle).State = EntityState.Modified;
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
                Bottle bottle = await dbo.Bottles.FindAsync(id);
                dbo.Bottles.Remove(Bottle);
                await dbo.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        private bool BottleExists(int id)
        {
            return dbo.Bottles.Count(e => e.BottleID == id) > 0;
        }  
  
    }
}