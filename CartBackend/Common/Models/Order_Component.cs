using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartBackend.Common.Models
{
    public class Order_Component
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public int ProductIdInOrder { get; set; }
        public Product Product { get; set; }
        public Component Component { get; set; }
        public int Quantity { get; set; }
    }
}
