using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartBackend.Common.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public bool Deleted { get; set; }
        public bool DiscountUsed { get; set; }
        public long OrderTimestamp { get; set; }
        public float Price { get; set; }
        public Discount Discount { get; set; }
        public User User { get; set; }
    }
}
