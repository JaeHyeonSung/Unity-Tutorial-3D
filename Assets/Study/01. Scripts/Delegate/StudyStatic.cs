using UnityEngine;

public class StudyStatic : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(StaticClass.number);
    }
}

public class StaticClass
{
    public static StaticClass instance = new StaticClass();
    public static int number = 10;

    public StaticClass()
    {
        Debug.Log($"생성자 실행 : {number}");
        

    }
}
