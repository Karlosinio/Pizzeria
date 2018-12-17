using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartBackend.Common.Models
{
    public class Order_Component
    {
        public Order Order { get; set; }
        //productIdInOrder
        public int ProductIdInOrder { get; set; }
        public Product Product { get; set; }
        public Component Component { get; set; }
        public int Quantity { get; set; }
    }
}
