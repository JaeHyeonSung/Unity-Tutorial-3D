using Pattern.Decorator;
using UnityEngine;

public class IceAttack : AttackDecorator
{
    public IceAttack(IAttack attack) : base(attack)
    {
    }
    public override void Execute()
    {
        base.Execute();
        Debug.Log("얼음 속성 추가피해");
    }
    
}
