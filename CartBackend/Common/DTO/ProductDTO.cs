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
        public Product Product { get; set; }
        public List<Component> Component { get; set; }
    }
}
