using CartBackend.Common.DTO;
using DeliveryBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryBackend.Helpers
{
    public static class DocumentData
    {
        public static double Price { get; set; }
        public static double PriceVat { get; set; }
        public static Address UserAdd { get; set; }
        public static Address PizzaAdd { get; set; } = new Address() { };
        public static List<ProductDTO> products {get;set;}
        public static int delivery { get; set; }
        public static string delNb { get; set; }



    }
}
