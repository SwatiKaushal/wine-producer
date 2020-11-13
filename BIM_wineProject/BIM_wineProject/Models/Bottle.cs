using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIM_wineProject.Models
{
    public class Bottle
    {
        public Bottle()
        {
            this.Producers = new HashSet<Producer>();
        }

        public int BottleID { get; set; }
        public string Name { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<int> Size { get; set; }
        public string styles { get; set; }
        public string taste { get; set; }
        public string C_Description { get; set; }
        public string Food_Pairing { get; set; }
        public string C_image { get; set; }
        public string link { get; set; }

        public virtual ICollection<Producer> Producers { get; set; }
    }
}