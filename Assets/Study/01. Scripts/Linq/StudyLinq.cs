using UnityEngine;
using System.Linq;
public class StudyLinq : MonoBehaviour
{
    public int[] numbers = { 1, 2, 3, 4, 5 };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var result = from number in numbers
                     where number >3
                     select number;

        foreach (var number in result)
        {
            Debug.Log(number);
        }
    }

    
}
