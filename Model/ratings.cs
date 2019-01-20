using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuModel
{
    public class ratings
    {
        //public int id { get; set; }
        public User user { get; set; }
        public int rate { get; set; }
        public string comment { get; set; }
        public string ratingTimestamp { get; set; }
    }
}
