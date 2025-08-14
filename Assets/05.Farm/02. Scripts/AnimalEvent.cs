using System;
using UnityEngine;

public class AnimalEvent : MonoBehaviour
{
    [SerializeField] private GameObject flag;
    private BoxCollider boxCollider;
    private float timer;
    private bool isTimer;

    public static Action failAction;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        failAction += SetRandomPosition;
    }
    private void Update()
    {
        if (!isTimer)
        {
            return;
        }
        timer += Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            isTimer = true;
            SetRandomPosition();
            GameManager.Instance.SetCameraState(CameraState.Animal);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log($"깃발 찾는데 걸린 시간은 {timer:F1}초 입니다.");
            SetFlag(Vector3.zero, false);
            isTimer = false;
            timer = 0f;
            GameManager.Instance.SetCameraState(CameraState.OutSide);
        }
    }

    void SetRandomPosition()
    {
        float randomX = UnityEngine.Random.Range(boxCollider.bounds.min.x, boxCollider.bounds.max.x);
        float randomZ = UnityEngine.Random.Range(boxCollider.bounds.min.z, boxCollider.bounds.max.z);

        var randomPos = new Vector3(randomX, 0f, randomZ);

        SetFlag(randomPos, true);
    }

    void SetFlag(Vector3 pos, bool isActive)
    {
        flag.transform.SetParent(transform);
        flag.transform.position = pos;
        flag.SetActive(isActive);
    }
}
