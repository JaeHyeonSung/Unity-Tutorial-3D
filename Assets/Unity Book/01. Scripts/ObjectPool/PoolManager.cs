using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    public ObjectPool<GameObject> pool;
    public GameObject prefab;
    private void Awake()
    {
        pool = new ObjectPool<GameObject>(CreateObject, OnGetObject, OnReleaseObject, OnDestroyObject);
    }

    private GameObject CreateObject()
    {
        GameObject obj = Instantiate(prefab);
        obj.SetActive(false);
        return obj;
    }

    void OnGetObject(GameObject obj)
    {
        Rigidbody rb= obj.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        obj.gameObject.transform.position = Vector3.zero;
        obj.SetActive(true);
    }

    void OnReleaseObject(GameObject obj)
    {
        obj.SetActive(false);
    }

    void OnDestroyObject(GameObject obj)
    {
        Destroy(obj);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = pool.Get();
            Debug.Log("오브젝트 생성");
            obj.SetActive(true);
        }
    }
}
