using UnityEngine;

public class Flag : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            transform.SetParent(other.transform); // 플레이어 자식으로 들어가기
        }
    }
}
