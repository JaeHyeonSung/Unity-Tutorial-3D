using System.Collections;
using UnityEngine;

public class IdleState :MonoBehaviour, IState
{
    public void StateEnter()
    {
        Debug.Log("Idle Enter");
        StartCoroutine(MethodA());
    }

    public void StateExit()
    {
        Debug.Log("Idle Exit");
    }

    public void StateUpdate()
    {
        Debug.Log("Idle");
    }

    IEnumerator MethodA()
    {
        yield return null;
    }
    
}
