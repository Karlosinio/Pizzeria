using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    public class OrderProduct
    {
        public int _id { get; set; }
        public Order _order { get; set; }
        public Product _product { get; set; }
        public int _quantity { get; set; }

        public OrderProduct(int id, Order order, Product product, int quantity)
        {
            _id = id;
            _order = order;
            _product = product;
        }
    }
}
