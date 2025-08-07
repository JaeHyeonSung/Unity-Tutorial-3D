using UnityEngine;

public class MoveState : MonoBehaviour, IState
{
    public void StateEnter()
    {
        Debug.Log("Move Enter");
    }

    public void StateExit()
    {
        Debug.Log("Move Exit");
    }

    public void StateUpdate()
    {
        Debug.Log("Move");
    }

    
}
