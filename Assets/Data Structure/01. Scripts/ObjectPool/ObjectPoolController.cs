using UnityEngine;

public class ObjectPoolController : MonoBehaviour
{
    public ObjectPoolQueue pool;
    public Transform shootPos;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = pool.DequeueObject();
            bullet.transform.position = shootPos.position;
        }
    }
}
