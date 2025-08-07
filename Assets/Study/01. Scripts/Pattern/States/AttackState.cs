using UnityEngine;

public class AttackState : MonoBehaviour, IState
{
    public void StateEnter()
    {
        Debug.Log("Attack Enter");
    }

    public void StateExit()
    {
        Debug.Log("Attack Exit");
    }

    public void StateUpdate()
    {
        Debug.Log("Attack");
    }

   
}
