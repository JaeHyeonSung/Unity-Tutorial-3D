using UnityEngine;

public class GameManager : Singleton<FPSGameManager>
{
    protected override void Awake()
    {
        base.Awake();
        Debug.Log("�߰��� ���");
    }
}
