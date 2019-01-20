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
        public bool Active { get; set; }
        public long ExpiereTimestamp { get; set; }
        public int PercentValue { get; set; }
        public long UseTimeStamp { get; set; }
        public bool Used { get; set; }

    }
}
