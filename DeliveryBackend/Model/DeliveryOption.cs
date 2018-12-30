using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryBackend.Model
{
    public class DeliveryOption
    {
        public int id {get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Boolean status { get; set; }
        //public double m_Price { get; set; }
        public Vehicle vehicle {get; set;}
    }
}
