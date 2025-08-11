using UnityEngine;

public abstract class PizzaStore : MonoBehaviour
{
    public Pizza OrderPizza(string type)
    {
        Pizza pizza = CreatePizza(type);

        return pizza;
    }

    protected abstract Pizza CreatePizza(string type);
}
