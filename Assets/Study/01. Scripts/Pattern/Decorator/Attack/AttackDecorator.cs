using Pattern.Decorator;
using UnityEngine;

public class AttackDecorator : IAttack
{
    protected IAttack attack;

    public AttackDecorator(IAttack attack)
    {
        this.attack = attack;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Execute()
    {
        attack.Execute();    
    }
}
