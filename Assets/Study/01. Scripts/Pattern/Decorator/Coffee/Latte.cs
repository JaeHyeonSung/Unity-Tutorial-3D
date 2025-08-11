using UnityEngine;

public class Latte : ICoffee
{
    public int Cost()
    {
        return 5500;
    }

    public string Description()
    {
        return "Latte";
    }

    
}
