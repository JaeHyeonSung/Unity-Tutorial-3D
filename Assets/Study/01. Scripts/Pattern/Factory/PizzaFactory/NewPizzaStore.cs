using UnityEngine;

public class NewPizzaStore : PizzaStore
{
    protected override Pizza CreatePizza(string type)
    {
        if (type.Equals("Normal"))
        {
            return new CheesePizza();
        }
        if (type.Equals("Special"))
        {
            return new ShrimpPizza();
        }
        return null;
    }
}
