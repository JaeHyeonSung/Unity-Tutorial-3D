using UnityEngine;

public class MochaDecorator : CoffeeDecorator
{
    public MochaDecorator(ICoffee coffee) : base(coffee)
    {

    }

    public override string Description()
    {
        return coffee.Description() + "Mocha";
    }

    public override int Cost()
    {
        return coffee.Cost() + 1000;
    }
}
