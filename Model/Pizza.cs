using System.Collections.Generic;

namespace MenuModel
{
    public class Pizza
    {
        public string m_Name { get; set; }
        public double m_Price { get; set; }
        public string m_Desciption { get; set; }

        public List<string> m_Allergens;
        public double m_PriceSmall { get; set; }
        public double m_PriceLarge { get; set; }
        public List<Ingredient> m_Ingredients;

        public Pizza(string name, double price, string desc, double price_small, double price_large, List<Ingredient> ingredients)
            
        {
            m_Name = name;
            m_Price = price;
            m_Desciption = desc;
            m_PriceSmall = price_small;
            m_PriceLarge = price_large;
            m_Ingredients = new List<Ingredient>(ingredients);
            //m_Allergens = new List<string>(allergens);
        }
    }
}
