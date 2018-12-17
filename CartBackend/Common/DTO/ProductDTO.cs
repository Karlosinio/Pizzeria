using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartBackend.Common.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Components { get; set; }
        public string Category { get; set; }
        public bool Available { get; set; }
        public List<Component> Component { get; set; }
    }
}
