using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartBackend.Common.Models
{
    public class Component
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public bool Vegan { get; set; }
    }
}
