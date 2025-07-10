using UnityEngine;

public class Permutation : MonoBehaviour
{
    public int[] array = new int[3] { 1, 2, 3 };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PermutationFunction(array, 0);
    }

    void PermutationFunction(int[] arr, int start)
    {
        if (start == arr.Length)
        {
            return;
        }

        for (int i=start; i<arr.Length; i++)
        {
            var temp = arr[start];
            arr[start] = arr[i];
            arr[i] = temp;

            PermutationFunction(arr, start + 1);

            temp = arr[start];
            arr[start] = arr[i];
            arr[i] = temp;
        }
    }
}
