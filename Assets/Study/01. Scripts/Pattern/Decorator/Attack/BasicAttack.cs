using UnityEngine;
using Pattern.Decorator;
public class BasicAttack : IAttack
{
    public void Execute()
    {
        Debug.Log("기본공격");
    }

    
}
