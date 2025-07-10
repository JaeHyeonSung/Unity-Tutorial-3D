using UnityEngine;

public class PoolObject : MonoBehaviour
{
    private ObjectPoolQueue pool;
    private float bulletSpeed = 30f;

    private void Awake()
    {
        pool = FindFirstObjectByType<ObjectPoolQueue>();
    }

    private void OnEnable()
    {
        Invoke("ReturnPool", 3f);
    }
    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * bulletSpeed;
    }
    void ReturnPool()
    {
        pool.EnqueueObjcet(gameObject);
    }
}
