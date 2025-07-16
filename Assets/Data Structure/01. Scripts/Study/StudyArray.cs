using UnityEngine;
using System;

public class StudyArray : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int[] array = new int[5];
        int[] array2 = new int[7];
        array[0] = 1;
        array[1] = 2;
        array[^3] = 3;
        array[^2] = 4;
        Debug.Log(array.Length);
        Array.ForEach(array, (x) => Debug.Log($"{x}"));


        Array.Copy(array, array2, array.Length);

        Array.ForEach(array2, (x) => Debug.Log($"{x}"));

    }

    
}
