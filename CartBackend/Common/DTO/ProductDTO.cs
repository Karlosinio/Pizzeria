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

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
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
