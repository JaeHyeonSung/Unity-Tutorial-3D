using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class ObjectPoolQueue : MonoBehaviour
{
    public Queue<GameObject> objQueue = new Queue<GameObject>();
    public GameObject objPrefab;
    public Transform parent;

    private void Start()
    {
        CreateObject();
    }

    private void CreateObject()
    {
        for (int i = 0; i < 30; i++)
        {
            GameObject obj = Instantiate(objPrefab, parent);
            EnqueueObjcet(obj);
        }
    }

    public void EnqueueObjcet(GameObject newObj)
    {
        objQueue.Enqueue(newObj);
        newObj.SetActive(false);
    }
    public GameObject DequeueObject()
    {
        if (objQueue.Count < 10) {
            CreateObject();
            
        }
        GameObject obj = objQueue.Dequeue();
        obj.SetActive(true);
        return obj;
    }
}
