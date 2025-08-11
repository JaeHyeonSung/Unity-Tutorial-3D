using UnityEngine;

public class Espresso : ICoffee
{
    public int Cost()
    {
        return 4000;
    }

    public string Description()
    {
        return "Espresso";
    }

    
}
