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
                double tmp = 0;
                tmp += _price;
                if(Component != null)
                {
                    foreach (var comp in Component)
                    {
                        tmp += comp.Quantity * comp.Component.Price;
                    }

                    return Quantity * tmp;
                }
                return Quantity * _price;
            }

            set { _price = value; } }
        public string ComponentToDisplay
        {
            get
            {

                Dictionary<string, int> components = new Dictionary<string, int>();

                string s = "";
                if (Component != null)
                {
                    foreach (var componentDTO in Component)
                    {
                        s += componentDTO.Component.Name + " x" + componentDTO.Quantity + " ";
                    }
                }

                return s;
            }
        }
        
        public string Category { get; set; }
        public bool Available { get; set; }
        public int Quantity { get; set; }
        public List<ComponentDTO> Component { get; set; }
    }
}
