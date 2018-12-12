using System;
using System.Collections.Generic;

namespace MenuModel
{
    public class Ingredient
    {
        public string m_Name { get; set; }
        public double m_Price { get; set; }
        //public string m_Desciption { get; set; }

        public List<String> m_Allergens = new List<string>();
        //public double m_PriceSmall { get; set; }
        //public double m_PriceLarge { get; set; }

        public Ingredient(string name, double price)
        {
            m_Name = name;
            m_Price = price;
        }
    }
}
