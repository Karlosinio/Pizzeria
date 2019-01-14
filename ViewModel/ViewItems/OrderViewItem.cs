using CartBackend.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ViewItems
{
    public class OrderViewItem
    {

        public int Id { get; set; }
        public string Comment { get; set; }
        public bool Deleted { get; set; }
        public bool DiscountUsed { get; set; }
        public float Price { get; set; }
        public string Date { get; set; }
        public string Discount { get; set; }


        public OrderViewItem(Order order)
        {
            Id = order.Id;
            Comment = order.Comment;
            Deleted = order.Deleted;
            DiscountUsed = order.DiscountUsed;
            Price = order.Price;
            Date = new DateTime(order.OrderTimestamp).ToShortDateString();
            if(order.Discount == null)
            {
                Discount = "";
            }
            else
            {
                Discount = order.Discount.Code;
            }


        }
    }
}
