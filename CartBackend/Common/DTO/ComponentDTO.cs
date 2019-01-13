using CartBackend.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartBackend.Common.DTO
{
    public class ComponentDTO
    {
        public int Quantity { get; set; }
        public Component Component { get; set; }
    }
}
