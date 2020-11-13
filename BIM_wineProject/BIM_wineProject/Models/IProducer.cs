using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIM_wineProject.Models
{
    interface IProducer
    {

        Task Add(Producer producer);
        Task Update(Producer producer);
        Task Delete(int id);
        Task<Producer> GetProducer(int id);
        Task<IEnumerable<Producer>> GetProducers();
    }
}
