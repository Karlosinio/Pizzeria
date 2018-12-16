using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartBackend.Common.Models
{
    public class OrderComponent
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ComponentId { get; set; }
        public int Quantity { get; set; }
    }
}
