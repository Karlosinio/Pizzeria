using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartBackend.Common.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int DiscountPrecent { get; set; }
        public DateTime? UseTime { get; set; }
        public bool IsUsed { get; set; }
        public DateTime ExpireTime { get; set; }
    }
}
