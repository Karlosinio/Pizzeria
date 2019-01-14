using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryViewModel
{
    public class Discount
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Code { get; set; }
        public long ExpireTimestamp { get; set; }
        public int PercentValue { get; set; }
        public long UseTimestamp { get; set; }
        public bool Used { get; set; }
    }
}
