using UnityEngine;

public class Shuffle : MonoBehaviour
{
    public int[] array = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    void Start()
    {
        ShuffleFunction();
    }


    void ShuffleFunction()
    {

    }
    public void Swap(int i, int j)
    {
        var temp = array[i];
        array[i] = array[j]; 
        array[j] = temp;
    }
}
