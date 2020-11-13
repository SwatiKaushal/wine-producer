using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM_wineProject.Models
{
    interface IBottle
    {

        Task Add(Bottle bottle);
        Task Update(Bottle bottle);
        Task Delete(int id);
        Task<Bottle> GetBottle(int id);
        Task<IEnumerable<Bottle>> GetBottles();
    }
}
