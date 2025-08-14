using UnityEngine;

public class BoardEvent : MonoBehaviour
{
    [SerializeField] private GameObject board;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SetCameraState(CameraState.Board);
            board.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SetCameraState(CameraState.House);
            board.SetActive(false);
        }
        
    }
}
