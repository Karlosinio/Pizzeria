using CartBackend.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryBackend.Model
{
    public class Delivery
    {
        public int id { get; set; }
        public Address address { get; set; }
        public DeliveryOption deliveryOption { get; set;}
        public Order order { get; set; }


        public Delivery(Address add, DeliveryOption del, Order or)
        {
            address = add;
            deliveryOption = del;
            order = or;
        }
        public Delivery()
        {

        }
    }
}
