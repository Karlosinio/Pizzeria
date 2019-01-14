using CartBackend.Common.Models;
using System;
using System.Collections.Generic;


namespace CartBackend.Common.DTO
{
    public class ProductDTO
    {
        public ProductDTO()
        {
        }

        private double _price = 0;

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get {
                return Quantity * _price;
            } set { _price = value; } }
        public string ComponentToDisplay
        {
            get;set;
        }

        public string Components { get; set; }
        public string Category { get; set; }
        public bool Available { get; set; }
        public int Quantity { get; set; }
    }
}
