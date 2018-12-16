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
        public int UserID { get; set; }
        public DateTime OrderTime { get; set; }
        public float Prize { get; set; }
        public string Comment { get; set; }
        public bool DiscountUsed { get; set; }
        public int? DiscountId { get; set; }
        public bool isDeleted { get; set; }
    }
}
