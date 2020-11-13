using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIM_wineProject.Models
{
    public class Producer
    {
        public int ProducerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Nullable<int> BottleID { get; set; }

        public virtual Bottle Bottle { get; set; }
    }
}