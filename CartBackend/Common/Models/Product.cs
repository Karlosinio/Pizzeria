using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartBackend
{
    // jest to część GUI, jednak do funkcjonowania naszej części musiałem to dodać
    public class Product
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        [JsonProperty("components")]
        public string Components { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("available")]
        public bool Available { get; set; }
    }
}
