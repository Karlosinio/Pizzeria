using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuModel
{
    public class product
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string components { get; set; }
        public string category { get; set; }
        public bool available { get; set; }
    }
}
