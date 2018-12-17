using CartBackend.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartBackend.Common.DTO
{
    public class OrderDTO
    {
        public OrderDTO()
        {
            Products = new List<Order_Product>();
        }

        public Order Order { get; set; }
        public List<Order_Product> Products { get; set; }
    }
}
