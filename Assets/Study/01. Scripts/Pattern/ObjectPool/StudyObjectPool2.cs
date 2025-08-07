using System;
using UnityEngine;
using UnityEngine.Pool;

public class StudyObjectPool2 : MonoBehaviour
{
    public ObjectPool<GameObject> objPool;
    public GameObject objPrefab;

    private void Awake()
    {
        objPool = new ObjectPool<GameObject>(CreateObject, GetObject, ReleaseObject);
    }

    private GameObject CreateObject()
    {
        GameObject obj = Instantiate(objPrefab, transform);
        obj.SetActive(false);

        return obj;
    }

    private void GetObject(GameObject obj)
    {
        obj.SetActive(true);
    }

    private void ReleaseObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}
