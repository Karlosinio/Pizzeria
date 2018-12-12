using System.Collections.Generic;

namespace MenuModel
{
    public class TmpBLL
    {
        public List<Pizza> pizzas;
        public TmpBLL()
        {
            Ingredient ser = new Ingredient("ser", 1.0);
            Ingredient salami = new Ingredient("salami", 1.5);
            Ingredient cebula = new Ingredient("cebula", 0.0);

            List<Ingredient> i1 = new List<Ingredient>
            {
                ser,
                salami
            };
            Pizza p1 = new Pizza("PEPPERONI", 23.00, "Fajna taka", 21.00, 25.00, i1);

            List<Ingredient> i2 = new List<Ingredient>
            {
                ser,
                cebula,
                salami
            };
            Pizza p2 = new Pizza("Wiejska", 24.00, "Fajna taka", 22.00, 26.00, i1);

            pizzas = new List<Pizza>
            {
                p1,
                p2
            };
        }
    }
}
