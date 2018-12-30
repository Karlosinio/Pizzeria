using CartBackend.Common.Models;
using System;
using System.Collections.Generic;


namespace CartBackend.Common.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ComponentToDisplay { get {

                Dictionary<string, int> components = new Dictionary<string, int>();

                string s = "";
                if (Component != null)
                {
                    foreach(var componentDTO in Component)
                    {
                        if (components.ContainsKey(componentDTO.Component.Name))
                        {
                            int prevValue = components[componentDTO.Component.Name];
                            components[componentDTO.Component.Name] = ++prevValue;
                        }
                        else
                        {
                            components.Add(componentDTO.Component.Name, 1);
                        }
                    }
                }

                foreach(var component in components)
                {
                    s += component.Key + " x" + component.Value + " ";
                }

                return s;
            } }
        public string Category { get; set; }
        public bool Available { get; set; }
        public int Quantity { get; set; }
        public List<ComponentDTO> Component { get; set; }

        public override bool Equals(object product)
        {
            var productDTO = (ProductDTO) product;

            if (product == null) return false;

            if (productDTO.Id != Id) return false;

                if (productDTO.Component.Count == Component.Count)
                {
                    int i = 0;
                    bool equal = true;
                    while (i < productDTO.Component.Count && equal)
                    {
                        if (productDTO.Component[i].Component.Id != Component[i].Component.Id)
                            equal = false;
                        i++;
                    }
                    if (equal)
                        return true;
                }

            return false;
            
        }
    }
}
