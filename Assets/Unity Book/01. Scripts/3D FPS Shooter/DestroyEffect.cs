using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    public float destroyTime = 2f;

    float currentTime = 0;

    private void Update()
    {
        if(currentTime > destroyTime)
        {
            Destroy(gameObject);
        }
        currentTime += Time.deltaTime;
    }
}
