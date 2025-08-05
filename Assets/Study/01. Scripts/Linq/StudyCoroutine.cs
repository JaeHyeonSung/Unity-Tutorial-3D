using System.Collections;
using UnityEngine;

public class StudyCoroutine : MonoBehaviour
{
    private IEnumerator enumerator;

    void Start()
    {
        enumerator = Numbers();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            enumerator.MoveNext();
            var result = enumerator.Current;

            Debug.Log(result);
        }
    }

    IEnumerator Numbers()
    {
        yield return 3;
        yield return 5;
        yield return 7;
    }
}