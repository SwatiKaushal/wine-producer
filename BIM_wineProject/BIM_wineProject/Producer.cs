

namespace BIM_wineProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class Producer
    {
        public int ProducerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Nullable<int> BottleID { get; set; }
    
        public virtual Bottle Bottle { get; set; }
    }
}
